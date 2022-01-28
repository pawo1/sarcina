using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Map
    {
        List<GameObject>[,] grid;

        public Map(int x, int y) {
            grid = new List<GameObject>[x, y];

            for(int i = 0; i < x; ++i)
            {
                for(int j = 0; j < y; ++j)
                {
                    grid[i, j] = new List<GameObject>();
                }
            }
        }
    }
}
