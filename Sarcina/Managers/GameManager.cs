using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

using Sarcina.CustomSerializators;
using Sarcina.Maps;
using Sarcina.Objects;

namespace Sarcina.Managers
{
    public class GameManager
    {
        public Map map;
        private Map mapRestorationBuffer;
        private Dictionary<string, GameObjectProps> dictBuffer;
        private GraphicManager graphicManager;

        public GameManager()
        {

        }

        public void LoadMap(string path)
        {
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            settings.Converters.Add(new GameObjectSerializator());

            string json = File.ReadAllText(path);
            map = JsonSerializer.Deserialize<Map>(json, settings);
            mapRestorationBuffer = CopyMap(map);
            dictBuffer = CopyDict(GameObject.GetDictionary());
        }

        public void SaveMap(string path)
        {
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            settings.Converters.Add(new GameObjectSerializator());

            string json = JsonSerializer.Serialize(map, settings);
            File.WriteAllText(path, json);
        }

        public void RestoreMap()
        {
            map = CopyMap(mapRestorationBuffer);
            GameObject.UpdateDictionary(CopyDict(dictBuffer));
        }

        private  Map CopyMap(Map original)
        {
            int height = original.Height;
            int width = original.Width;

            Map copy = new Map(height, width);

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    foreach (GameObject obj in original.Grid[i][j])
                    {
                        copy.Grid[i][j].Add(obj.ShallowCopy());
                    }
                }
            }

            return copy;
        }

        private  Dictionary<string, GameObjectProps> CopyDict(Dictionary<string, GameObjectProps> original)
        {
            Dictionary<string, GameObjectProps> copy = new Dictionary<string, GameObjectProps>();
            copy = original.ToDictionary(entry => entry.Key, entry => (GameObjectProps)entry.Value.Clone()); // deep copy
            return copy; 
        }



    }
}
