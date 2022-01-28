using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    [Serializable]
    public class Map
    {
        public List<GameObject>[,] Grid { get; private set; }

        public Map(int x, int y) {
            Grid = new List<GameObject>[x, y];

            for(int i = 0; i < x; ++i)
            {
                for(int j = 0; j < y; ++j)
                {
                    Grid[i, j] = new List<GameObject>();
                }
            }
        }
    }
}
