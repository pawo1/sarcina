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

        public bool IsWall { set; get; }

        public bool IsMoveable { set; get; }

        private static Dictionary<string, int> dict = new Dictionary<string, int>();

        public int Field
        {
            get
            {
                return dict.ContainsKey(this.GetType().Name)
                   ? dict[this.GetType().Name] : default(int);
            }
            set
            {
                dict[this.GetType().Name] = value;
            }
        }

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
    }
}
