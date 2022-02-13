using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Sarcina.Objects;
using System.Text.Json.Serialization;

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
            Grid[x][y].Add(newObject);
        }

        /// <summary>
        /// Aktualizuje pozycje wszystkich elementów na planszy
        /// </summary>
        /// <param name="move">Wektor ruchu w kartezjańskim układzie współrzędnych</param>
        public void Update(Vector2 move)
        {
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
                MoveObject(queue.Dequeue(), move, queue);
            }
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
        private bool MoveObject(Vector2 position, Vector2 move, Queue<Vector2> queue)
        {
            Vector2 newPosition = position + move;
            Field sourceField = GetAt(position);
            Field destinationField = GetAt(newPosition);
            Portal portal = destinationField.GetPortal();
            if(portal != null)
            {
                newPosition = portal.connectedPortal;
                destinationField = GetAt(newPosition);
            }

            if (destinationField.CanEnter()) // no immoveable objects
            {
                List<GameObject> moveableObjects = destinationField.GetMoveable();
                if(moveableObjects.Count == 0) // nothing to push
                {
                    MovePlayers(sourceField, destinationField);
                    return true;
                }
                Vector2 movedToPosition = newPosition + move;
                if (!IsValid(movedToPosition)) return false; // cannot push items
                Field movedToField = GetAt(movedToPosition);

                if(movedToField.CanEnter() && !movedToField.HasMoveableObjects()) // field is empty
                {
                    var playerObjects = sourceField.GetPlayers();
                    movedToField.AddRange(moveableObjects);
                    destinationField.RemoveAll((gameObject) => { return gameObject.IsMoveable; });

                    destinationField.AddRange(playerObjects);
                    sourceField.RemoveAll((gameObject) => { return gameObject.IsControlledByPlayer; });
                }
            }

            return false;
        }

        private void MovePlayers(Field source, Field destination)
        {
            var playerObjects = source.GetPlayers();
            destination.AddRange(playerObjects);
            source.RemoveAll((gameObject) => { return gameObject.IsControlledByPlayer; });
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

        private void SetAt(Vector2 position, Field objects) 
        {
            Grid[(int)position.Y][(int)position.X] = objects;
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
