using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Button : GameObject
    {
        public Vector2 ConnectedTerminal { get; private set; }

        public Button() : this(-1) { }

        public Button(Vector2 connectedTerminal) : this(-1) 
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
