using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sarcina.Objects;

using System.Text.Json.Serialization;

namespace Sarcina.Maps
{
    [Serializable]
    public class Field //: IEnumerable
    {

        public List<GameObject> GameObjects { private set; get; }

        public int Count { get => GameObjects.Count; }

        public Field()
        {
             GameObjects = new List<GameObject>();
        }

        [JsonConstructorAttribute]
        public Field(List<GameObject> gameObjects)
        {
            GameObjects = gameObjects;
        }


        public bool CanEnter()
        {
           foreach(GameObject gameObject in GameObjects)
            {
                if (gameObject.IsWall) return false;
            } 
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return GameObjects.GetEnumerator();
        }

        public void Add(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public List<GameObject> GetMoveable()
        {
            List<GameObject> moveableObjects = new List<GameObject>();

            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.IsMoveable) moveableObjects.Add(gameObject);
            }

            return moveableObjects;
        }
    }
}
