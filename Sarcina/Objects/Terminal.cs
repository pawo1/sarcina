﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Terminal : GameObject
    {
        [JsonInclude]
        public List<Box> SavedBoxes { get; set; } = new List<Box>();

        [JsonInclude]
        public int Count { get => SavedBoxes.Count; }

        public Terminal() : this(-1) { }

        public Terminal(int spriteId) : base(spriteId)
        {
            IsControlledByPlayer = false;
            IsWall = false;
            IsMoveable = false;
        }

        public Terminal(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        { }

        [JsonConstructor]
        public Terminal(int spriteId, bool isControlledByPlayer, bool isWall, bool isMoveable, List<Box> savedBoxes) :
            base(spriteId, isControlledByPlayer, isWall, isMoveable)
        {
            SavedBoxes = savedBoxes;
        }

        public override Terminal ShallowCopy()
        {
            Terminal copy = (Terminal)this.MemberwiseClone();
            copy.SavedBoxes = this.SavedBoxes.ConvertAll(box => (Box)box.Clone());
            return (Terminal)this.MemberwiseClone();
        }
    }
}
