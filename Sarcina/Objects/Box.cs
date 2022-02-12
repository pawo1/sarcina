using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Box : GameObject
    {
        public Box() : this(-1) { }

        public Box(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = false;
            IsWall = false;
            IsMoveable = true;
        }

        public Box(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }
    }
}
