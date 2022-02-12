using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sarcina.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

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

        }

    }
}
