﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Portal : GameObject
    {

        //public Vector2 connectedPortal;

        public Portal(int spriteId) : base(spriteId)
        {}
        public Portal() : base()
        { }

        [JsonConstructorAttribute]
        public Portal(int spriteId, bool isControlledByPlayer) : base(spriteId, isControlledByPlayer)
        {
            //this.connectedPortal = connectedPortal;
        }

        public override Portal ShallowCopy()
        {
            return (Portal)this.MemberwiseClone();
        }
    }
}
