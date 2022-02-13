using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Button : GameObject
    {
        public VectorObject ConnectedTerminal { get; set; } = new VectorObject(-1, -1);

        public Button() : this(-1) { }

        public Button(VectorObject connectedTerminal) : this(-1) 
        {
            ConnectedTerminal = connectedTerminal;
        }

        public Button(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = false;
            IsWall = false;
            IsMoveable = false;
        }

        public Button(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }

        public override Button ShallowCopy()
        {
            return (Button)this.MemberwiseClone();
        }
    }
}
