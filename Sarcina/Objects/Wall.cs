using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Wall : GameObject 
    {
        public Wall() : this(2) { }

        public Wall(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = false;
            IsWall = true;
            IsMoveable = false;
        }

        public Wall(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }
    }
}
