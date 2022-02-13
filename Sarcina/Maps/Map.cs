using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Sarcina.Objects;
using System.Text.Json.Serialization;
using System.Text.Json;
using Sarcina.CustomSerializators;

namespace Sarcina.Maps
{
    [Serializable]
    public class Map
    {

        public int Height { get; private set; }
        public int Width { get; private set; }
        public List<List<Field>> Grid { get; private set; }

        public Map(int height, int width) {
            Width = width;
            Height = height;

            Grid = new List<List<Field>>();

            for(int i = 0; i < Height; ++i)
            {
                Grid.Add(new List<Field>());
                for(int j = 0; j < Width; ++j)
                {
                    Grid[i].Add( new Field() );
                }
            }
        }

        [JsonConstructorAttribute]
        public Map(int height, int width, List<List<Field>> grid)
        {
            Height = height;
            Width = width;
            Grid = grid;
        }

        public void TestSet(int x, int y, GameObject newObject)
        {
            Grid[y][x].Add(newObject);
        }


        public List<int> getSpritesId(int x, int y)
        {
            List<int> list = new List<int>();
            foreach(var obj in Grid[y][x].getSorted())
            {
                list.Add(obj.SpriteId);
            }
            return list;
        }


        public string getJson()
        {
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            settings.Converters.Add(new GameObjectSerializator());

            string json = JsonSerializer.Serialize(this, settings);
            return json;
        }

        /// <summary>
        /// Aktualizuje pozycje wszystkich elementów na planszy
        /// </summary>
        /// <param name="move">Wektor ruchu w kartezjańskim układzie współrzędnych</param>
        public int Update(Vector2 move)
        {
            int moved = 0;
            move.Y *= -1; // TODO: usunąć przy mapowaniu klawisz -> wektor

            Queue<Vector2> queue = new Queue<Vector2>();
            int maxField = Width * Height;
            for (int i = 0; i < maxField; i++)
            {
                Vector2 position = GetPosition(i, move);
                //Debug.WriteLine(String.Format("({0},{1})", position.X, position.Y));
                if (IsFieldMoveable(position, move))
                    queue.Enqueue(position);
                //Display();
            }

            while (queue.Count > 0)
            {
                if (MoveObject(queue.Dequeue(), move, queue))
                    moved++;
            }

            return moved;
        }

        private bool IsFieldMoveable(Vector2 position, Vector2 move)
        {
            Vector2 newPosition = position + move;
            if (!IsValid(position) || !IsValid(newPosition))
                return false; // invalid position

            Field sourceField = GetAt(position);
            if (sourceField.HasPlayers())
            {
                Field destinationField = GetAt(newPosition);
                if(destinationField.CanEnter() || destinationField.HasMoveableObjects())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Porusza obiekty z pozycji position o ruch move. Może aktualizować kolejkę queue
        /// </summary>
        /// <param name="position">Obecna pozycja</param>
        /// <param name="move">Wektor ruchu w układzie z odwróconą osią Y</param>
        /// <returns>Czy ruch wykonany pomyślnie</returns>
        private bool MoveObject(Vector2 position, Vector2 move, Queue<Vector2> queue, bool exitingPortal = false)
        {
            Vector2 newPosition = position + move;

            if (!IsValid(position) || !IsValid(newPosition))
                return false; // invalid position

            Field sourceField = GetAt(position);
            Field destinationField = GetAt(newPosition);
            // cannot enter field, cannot move
            if (!destinationField.CanEnter()) return false;

            // -> you can enter next field

            // moving boxes failed, cannot move
            if (!MoveBoxes(newPosition, move, queue)) return false;

            // -> field you try to enter is now empty

            Portal portal = destinationField.GetPortal();
            // there is no portal
            // or they just passed through the portal
            if (portal == null || exitingPortal)
            {
                MovePlayerObjects(sourceField, destinationField);
                return true;
            }

            // -> there is a portal

            // portal is invalid
            if (!IsValid(portal.connectedPortal))
            {
                MovePlayerObjects(sourceField, destinationField);
                return true;
            }

            // -> there is valid portal

            Field portalField = GetAt(portal.connectedPortal);
            // you can neither enter portal
            //  nor move the boxes there, stay on top
            if (!portalField.CanEnter() || !MoveBoxes(portal.connectedPortal, move, queue))
            {
                MovePlayerObjects(sourceField, destinationField);
                return true;
            }

            // -> portal is available to enter and boxes have been moved

            MovePlayerObjects(sourceField, portalField);
            return true;
        }

        private bool MoveBoxes(Vector2 position, Vector2 move, Queue<Vector2> queue, bool exitingPortal = false)
        {
            Field boxesField = GetAt(position);
            // no boxes, nothing to move, move completed
            if (!boxesField.HasMoveableObjects()) return true;

            // -> there are boxes to move

            // position has been validated before
            Vector2 moveToPosition = position + move;
            // invalid position, cannot move
            if (!IsValid(moveToPosition)) return false;

            // -> now moveToPosition is valid

            Field moveToField = GetAt(moveToPosition);
            // cannot enter or has other moveable, cannot move
            if (!moveToField.CanEnter() || moveToField.HasMoveableObjects()) return false;

            // -> there is place to move the boxes

            Portal portal = moveToField.GetPortal();
            // there is no portal, can move
            // or they just passed through the portal
            if (portal == null || exitingPortal)
            {
                MoveBoxObjects(boxesField, moveToField);
                return true;
            }

            // -> there is a portal

            // portal is invalid
            if (!IsValid(portal.connectedPortal))
            {
                MoveBoxObjects(boxesField, moveToField);
                return true;
            }

            Field portalField = GetAt(portal.connectedPortal);
            // you can neither enter portal
            //  nor move the boxes there, stay on top
            if (!portalField.CanEnter() || portalField.HasMoveableObjects())
            {
                MoveBoxObjects(boxesField, moveToField);
                return true;
            }

            move = portal.connectedPortal - position;
            // check new move to the connected portal
            return MoveBoxes(position, move, queue, true);
        }

        private void MovePlayerObjects(Field source, Field destination)
        {
            var playerObjects = source.GetPlayers();
            destination.AddRange(playerObjects);
            source.RemoveAll((gameObject) => { return gameObject.IsControlledByPlayer; });
        }

        private void MoveBoxObjects(Field source, Field destination)
        {
            var boxes = source.GetMoveable();
            destination.AddRange(boxes);
            source.RemoveAll((gameObject) => { return gameObject.IsMoveable; });
        }

        private bool IsValid(Vector2 position)
        {
            return position.X >= 0 && position.X < Width
                && position.Y >= 0 && position.Y < Height;
        }

        private Field GetAt(Vector2 position)
        {
            return Grid[(int)position.Y][(int)position.X];
        }

        /// <summary>
        /// Zwraca pozycję w tabeli według iteracji
        /// </summary>
        /// <param name="k">Iteracja</param>
        /// <param name="move">Wektor ruchu z odwróconą osią Y</param>
        /// <returns></returns>
        private Vector2 GetPosition(int k, Vector2 move)
        {
            switch (move){
                case { X: -1,  Y: 0 }:  // moving left, checking right->left
                    return new Vector2(k / Height, k % Height);
                case { X: 1,  Y: 0 }:   // moving right, checking left->right
                    return new Vector2(Width - 1 - k / Height, k % Height);

                case { X: 0,  Y: -1 }:  // moving up, check up->down
                    return new Vector2(k % Width, k / Width);
                case { X: 0, Y: 1 }:   // moving down, check down->up
                    return new Vector2( k % Width, Height - 1 - k / Width);
            }
            return new Vector2(0, 0);
        }
        public void Display()
        {
            Debug.WriteLine("Map:");
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    //Debug.Write(String.Format("{0}:({1},{2})\t", Grid[i][j].ToString(), j, i));
                    Debug.Write(String.Format("{0}\t", Grid[i][j].ToString()));
                }
                Debug.WriteLine("");
            }
        }
    }

}
