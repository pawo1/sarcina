using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sarcina.Objects;

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
            GameObject gameObject = new Portal();
        }
    }
}
