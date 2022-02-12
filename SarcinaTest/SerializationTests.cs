using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

using Sarcina.Objects;
using Sarcina.Maps;
using Sarcina.CustomSerializators;

namespace SarcinaTest
{
    [TestClass]
    public class SerializationTests
    {


        [TestMethod]
        public void CreateGameObject()
        {
            GameObject gameObject = new Player(28012022);

            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            settings.Converters.Add(new GameObjectSerializator());

            string json = JsonSerializer.Serialize(gameObject, settings);
            File.WriteAllText("GameObjectSerial.json", json);

            GameObject gameObject2 = JsonSerializer.Deserialize<GameObject>(json, settings);

            Assert.AreEqual(gameObject.SpriteId, gameObject2.SpriteId);
        }

        [TestMethod]
        public void SerializeMap()
        {

            int x = 2;
            int y = 3;
            Map map = new Map(x, y);
            
            for(int i=0; i<x; ++i)
            {
                for(int j=0; j<y; ++j)
                {
                    Player player = new Player();
                    Portal portal = new Portal();

                    map.TestSet(i, j, player);
                    if (j % 2 == 0)
                        map.TestSet(i, j, portal);
                }
            }


            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            settings.Converters.Add(new GameObjectSerializator());

            string json = JsonSerializer.Serialize(map, settings);
            File.WriteAllText("MapSerial.json", json);

            Map mapDes = JsonSerializer.Deserialize<Map>(json, settings);

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    Assert.AreEqual(map.Grid[i][j].Count, mapDes.Grid[i][j].Count);
                }
            }

        }

        [TestMethod]
        public void SerializeField()
        {
            Field field = new Field();
            Player player = new Player();
            field.Add(player);

            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            settings.Converters.Add(new GameObjectSerializator());

            string json = JsonSerializer.Serialize(field, settings);

            File.WriteAllText("MapSerial.json", json);
            string jsonRead = File.ReadAllText("MapSerial.json");

            var fieldDes = JsonSerializer.Deserialize<Field>(jsonRead, settings);
            
            Assert.AreEqual(field.Count, fieldDes.Count);

        }

    }
}
