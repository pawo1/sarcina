using System;
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

        [JsonIgnore]
        public int Count { get => SavedBoxes.Count; }

        [JsonIgnore]
        public Box LastBox { 
            get
            {
                if (Count > 0)
                {
                    Box box = SavedBoxes[^1];
                    SavedBoxes.Remove(box);
                    return box;
                }
                return null;
            }
            set => SavedBoxes.Add(value); 
        }

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
            return (Terminal)this.MemberwiseClone();
        }
    }
}
