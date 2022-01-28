using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Sarcina.Objects
{
    [Serializable]
    public abstract class GameObject
    {
        public int SpriteId { private set; get; } = -1;

        public bool IsControlledByPlayer { set; get; } = false;

        public GameObject(int spriteId = -1)
        {
            SpriteId = spriteId;
        }

        [JsonConstructorAttribute]
        public GameObject(int spriteId, bool isControlledByPlayer)
        {
            SpriteId = spriteId;
            IsControlledByPlayer = isControlledByPlayer;
        }

        public bool TryMove(Vector2 vector)
        {



            return true;
        }
    }
}
