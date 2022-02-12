using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
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

        public void Update(Vector2 move)
        {
            int maxField = Width * Height;
            for (int i = 0; i < maxField; i++)
            {
                Vector2 position = GetPosition(i, move);
                Debug.WriteLine("({0}, {1})", position.X, position.Y);

                MoveObject(position, position + move);
            }
        }

        private bool MoveObject(Vector2 position, Vector2 newPosition)
        {
            if (!IsValid(position) || !IsValid(newPosition)) return false; // invalid position

            Field sourceObjects = GetAt(position);
            if (sourceObjects.Count == 0) return true; // nothing to move

            Field destinationObjects = GetAt(newPosition);
            /*if (destinationObjects.Count == 0) // anything can be moved
            {

            }*/

            return true;
        }

        private bool IsValid(Vector2 position)
        {
            return position.X < 0 || position.X >= Width
                || position.Y < 0 || position.Y >= Height;
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
