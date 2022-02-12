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
        public List<GameObject>[,] Grid { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(int height, int width) {
            Width = width;
            Height = height;

            Grid = new List<GameObject>[Height, Width];

            for(int i = 0; i < Height; ++i)
            {
                for(int j = 0; j < Width; ++j)
                {
                    Grid[i, j] = new List<GameObject>();
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
            }
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
