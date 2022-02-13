using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Sarcina.Objects
{
    [Serializable]
    public class VectorObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static VectorObject operator +(VectorObject a, VectorObject b)
        {
            return new VectorObject(a.X + b.X, a.Y + b.Y);
        }

        public static VectorObject operator -(VectorObject a, VectorObject b)
        {
            return new VectorObject(a.X - b.X, a.Y - b.Y);
        }

        [JsonConstructorAttribute]
        public VectorObject(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
