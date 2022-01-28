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
        public Portal(int spriteId) : base(spriteId)
        {}
        public Portal() : base()
        { }

        [JsonConstructorAttribute]
        public Portal(int spriteId, bool isControlledByPlayer) : base(spriteId, isControlledByPlayer)
        {
        }
    }
}
