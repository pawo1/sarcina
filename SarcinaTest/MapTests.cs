using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sarcina.Objects;
using System.Runtime.Serialization;
using System.Text.Json;
using System.IO;

namespace SarcinaTest
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void CreateMap()
        {
            Map map = new Map(5, 5);
        }

        [TestMethod]
        public void CreateGameObject()
        {
            GameObject gameObject = new Portal(28012022);

            string json = JsonSerializer.Serialize(gameObject);
            File.WriteAllText("GameObjectSerial.json", json);

            GameObject gameObject2 = JsonSerializer.Deserialize<Portal>(json);

            Assert.AreEqual(gameObject.SpriteId, gameObject2.SpriteId);
        }
    }
}
