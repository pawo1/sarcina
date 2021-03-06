using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Grass : GameObject
    {
        public Grass() : this(4) { }

        public Grass(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = false;
            IsWall = true;
            IsMoveable = false;
        }

        public Grass(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }
    }
}
