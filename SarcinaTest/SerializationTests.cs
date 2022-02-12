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

namespace SarcinaTest
{
    [TestClass]
    public class SerializationTests
    {


        [TestMethod]
        public void CreateGameObject()
        {
            GameObject gameObject = new Portal(28012022);

            string json = JsonSerializer.Serialize(gameObject);
            File.WriteAllText("GameObjectSerial.json", json);

            GameObject gameObject2 = JsonSerializer.Deserialize<Portal>(json);

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
                    if (y % 2 == 0)
                        map.TestSet(i, j, portal);
                }
            }

            string json = JsonSerializer.Serialize(map);
            File.WriteAllText("MapSerial.json", json);

            Map mapDes = JsonSerializer.Deserialize<Map>(json);

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    Assert.AreEqual(map.Grid[i, j], mapDes.Grid[i, j]);
                }
            }

        }

    }
}
