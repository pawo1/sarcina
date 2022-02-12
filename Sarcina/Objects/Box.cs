using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Box : GameObject
    {
        public Box(int spriteId, bool isControlledByPlayer) : base(spriteId, isControlledByPlayer)
        {
            IsMoveable = true;
        }
    }
}
