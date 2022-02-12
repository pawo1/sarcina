using Sarcina.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcina.Maps
{
    [Serializable]
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

        public List<GameObject> GetPlayers()
        {
            List<GameObject> moveableObjects = new List<GameObject>();

            foreach (GameObject gameObject in this)
            {
                if (gameObject.IsControlledByPlayer) moveableObjects.Add(gameObject);
            }

            return moveableObjects;
        }

        public override string ToString()
        {
            if (Count == 0) return ".";

            StringBuilder stringBuilder = new StringBuilder();
            foreach (GameObject gameObject in this)
            {
                if (gameObject is Player) stringBuilder.Append('P');
                else if (gameObject is Portal) stringBuilder.Append('O');
            }

            return stringBuilder.ToString();
        }
    }
}
