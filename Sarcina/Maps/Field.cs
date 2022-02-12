using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sarcina.Objects;


namespace Sarcina.Maps
{
    [Serializable]
    public class Field : IEnumerable
    {
        public List<GameObject> GameObjects = new List<GameObject>();

        public int Count { get => GameObjects.Count; }


        public bool CanEnter()
        {
            foreach(GameObject gameObject in this)
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

            foreach (GameObject gameObject in this)
            {
                if (gameObject.IsMoveable) moveableObjects.Add(gameObject);
            }

            return moveableObjects;
        }
    }
}
