using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Player : GameObject
    {
        public Player(int spriteId = 0) : base(spriteId)
        {
            IsControlledByPlayer = true;
        }

        public override string ToString()
        {
            return "Player";
        }
    }
}
