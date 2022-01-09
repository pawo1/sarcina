using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public abstract class GameObject
    {
        public int SpriteId { private set; get; } = -1;

        public bool IsControlledByPlayer { set; get; } = false;

        public GameObject(int spriteId)
        {
            SpriteId = spriteId;
        }
    }
}
