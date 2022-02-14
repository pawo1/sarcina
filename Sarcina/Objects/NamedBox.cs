using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class NamedBox : Box
    {
        public NamedBox() : this(16) { }

        public NamedBox(int spriteId) : base(spriteId)
        { }

        public NamedBox(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }
    }
}
