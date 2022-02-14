using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Player : GameObject
    {

        public Player() : this(18) { }

        public Player(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = true;
            IsWall = false;
            IsMoveable = false;
        }

        public Player(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }

        public override string ToString()
        {
            return "Player";
        }
    }
}
