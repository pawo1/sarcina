using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Objects
{
    public class Field : List<GameObject>
    {
        public bool CanEnter()
        {
            foreach(GameObject gameObject in this)
            {
                if (gameObject.IsWall) return false;
            }
            return true;
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
