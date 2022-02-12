using Sarcina.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

        public bool HasMoveableObjects()
        {
            foreach (GameObject gameObject in this)
            {
                if (gameObject.IsMoveable) return true;
            }

            return false;
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
                else if (gameObject is Box) stringBuilder.Append('B');
            }

            return stringBuilder.ToString();
        }

        internal void AddRange(List<GameObject> playerObjects)
        {
            GameObjects.AddRange(playerObjects);
        }

        internal void RemoveAll(Predicate<GameObject> predicate)
        {
            GameObjects.RemoveAll(predicate);
        }
    }
}
