using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Portal : GameObject
    {
        //public Vector2 connectedPortal;

        public Portal() : this(-1) { }

        public Portal(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = false;
            IsWall = false;
            IsMoveable = false;
        }

        public Portal(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }
    }
}
