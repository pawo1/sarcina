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


        private static Dictionary<string, GameObjectProps> propDict = new Dictionary<string, GameObjectProps>();


        public static Dictionary<string, GameObjectProps> GetDictionary()
        {
            return propDict;
        }

        public static void UpdateDictionary(Dictionary<string, GameObjectProps> dict)
        {
            propDict = dict;
        }

        public int SpriteId
        {
            get
            {
                return propDict.ContainsKey(this.GetType().Name)
                   ? propDict[this.GetType().Name].SpriteId : default(int);
            }
            set
            {
                if (!propDict.ContainsKey(this.GetType().Name))
                {
                    propDict[this.GetType().Name] = new GameObjectProps();
                }

                propDict[this.GetType().Name].SpriteId = value;
            }
        }

        public bool IsControlledByPlayer
        {
            get
            {
                return propDict.ContainsKey(this.GetType().Name)
                   ? propDict[this.GetType().Name].IsControlledByPlayer : default(bool);
            }
            set
            {
                if (!propDict.ContainsKey(this.GetType().Name))
                {
                    propDict[this.GetType().Name] = new GameObjectProps();
                }

                propDict[this.GetType().Name].IsControlledByPlayer = value;
                
            }
        }

        public bool IsWall 
        {
            get
            {
                return propDict.ContainsKey(this.GetType().Name)
                   ? propDict[this.GetType().Name].IsWall : default(bool);
            }
            set
            {
                if (!propDict.ContainsKey(this.GetType().Name))
                {
                    propDict[this.GetType().Name] = new GameObjectProps();
                }

                propDict[this.GetType().Name].IsWall = value;
            }
        }

        public bool IsMoveable
        {
            get
            {
                return propDict.ContainsKey(this.GetType().Name)
                   ? propDict[this.GetType().Name].IsMoveable : default(bool);
            }
            set
            {
                if (!propDict.ContainsKey(this.GetType().Name))
                {
                    propDict[this.GetType().Name] = new GameObjectProps();
                }

                propDict[this.GetType().Name].IsMoveable = value;
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

        public virtual GameObject ShallowCopy()
        {
            return (GameObject)this.MemberwiseClone();
        }
    }
}
