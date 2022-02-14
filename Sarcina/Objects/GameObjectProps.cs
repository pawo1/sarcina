using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class GameObjectProps : ICloneable
    {
        public int SpriteId { set; get; } = 0;

        public bool IsControlledByPlayer { set; get; } = false;

        public bool IsWall { set; get; }

        public bool IsMoveable { set; get; }

        public object Clone()
        {
            GameObjectProps clone = (GameObjectProps)this.MemberwiseClone();
            return clone;
        }

    }
}
