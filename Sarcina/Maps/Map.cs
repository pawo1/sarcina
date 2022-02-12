﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Sarcina.Objects;

namespace Sarcina.Maps
{
    [Serializable]
    public class Map
    {
        public Field[,] Grid { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(int height, int width) {
            Width = width;
            Height = height;

            Grid = new Field[Height, Width];

            for(int i = 0; i < Height; ++i)
            {
                for(int j = 0; j < Width; ++j)
                {
                    Grid[i, j] = new Field();
                }
            }
        }

        public void TestSet(int x, int y, GameObject newObject)
        {
            Grid[x, y].Add(newObject);
        }

        public void Update(Vector2 move)
        {
            int maxField = Width * Height;
            for (int i = 0; i < maxField; i++)
            {
                Vector2 position = GetPosition(i, move);
                Debug.WriteLine("({0}, {1})", position.X, position.Y);

                MoveObject(position, move);
            }
        }

        public void Display()
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    Debug.Write("{0}\t", Grid[i, j].ToString());
                }
                Debug.WriteLine("");
            }
        }

        private bool MoveObject(Vector2 position, Vector2 move)
        {
            Vector2 newPosition = position + move;
            if (!IsValid(position) || !IsValid(newPosition)) return false; // invalid position

            Field sourceField = GetAt(position);
            if (sourceField.Count == 0) return true; // nothing to move

            Field destinationField = GetAt(newPosition);
            if (destinationField.Count == 0) // anything can be moved
            {
                MovePlayers(sourceField, destinationField);
                return true;
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

                    movedToField.AddRange(playerObjects);
                    destinationField.RemoveAll((gameObject) => { return gameObject.IsControlledByPlayer; });
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
            return position.X > 0 && position.X < Width
                && position.Y > 0 && position.Y < Height;
        }

        private Field GetAt(Vector2 position)
        {
            return Grid[(int)position.X, (int)position.Y];
        }

        private void SetAt(Vector2 position, Field objects) 
        {
            Grid[(int)position.X, (int)position.Y] = objects;
        }

        private Vector2 GetPosition(int k, Vector2 move)
        {
            switch (move){
                case { X: 0,  Y: -1 }: // down
                    return new Vector2(k / Width, k % Width);
                case { X: 0,  Y: 1 }:  // up
                    return new Vector2(Height - 1 - k / Width, k % Width);
                case { X: 1,  Y: 0 }:  // right
                    return new Vector2(k % Height, k / Height);
                case { X: -1, Y: 0 }: // left
                    return new Vector2( k % Height, Width - 1 - k / Height);
            }
            return new Vector2(0, 0);
        }
    }
}
