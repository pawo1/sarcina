using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Portal : GameObject
    {
        public VectorObject ConnectedPortal { get; set; } = new VectorObject(-1, -1);

        public Portal() : this(9) { }

        public Portal(VectorObject connectedPortal) : this(9)
        {
            ConnectedPortal = connectedPortal;
        }

        public Portal(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = false;
            IsWall = false;
            IsMoveable = false;
        }

        public Portal(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable,
            VectorObject connectedPortal) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        {
            ConnectedPortal = connectedPortal;
        }

        public override Portal ShallowCopy()
        {
            return (Portal)this.MemberwiseClone();
        }
    }
}
