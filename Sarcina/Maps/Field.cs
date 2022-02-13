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
                if (gameObject.IsMoveable && !gameObject.IsWall) return true;
            }

            return false;
        }

        public bool HasPlayers()
        {
            foreach (GameObject gameObject in this)
            {
                if (gameObject.IsControlledByPlayer) return true;
            }

            return false;
        }

        public Portal GetPortal()
        {
            foreach (GameObject gameObject in this)
            {
                if (gameObject is Portal portal) return portal;
            }

            return null;
        }

        public Terminal GetTerminal()
        {
            foreach (GameObject gameObject in this)
            {
                if (gameObject is Terminal terminal) return terminal;
            }

            return null;
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
                if (gameObject.IsMoveable && !gameObject.IsWall) moveableObjects.Add(gameObject);
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
                else if (gameObject is Portal) stringBuilder.Append('X');
                else if (gameObject is Box) stringBuilder.Append('B');
                else if (gameObject is Wall) stringBuilder.Append('W');
                else if (gameObject is Grass) stringBuilder.Append('G');
                else if (gameObject is Objective) stringBuilder.Append('O');
            }

            return stringBuilder.ToString();
        }

        public bool IsWinCondition()
        {
            int objectives = 0;
            int boxes = 0;
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject is Box) boxes++;
                else if (gameObject is Objective) objectives++;
            }

            return objectives == 0 || boxes >= 1;
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
