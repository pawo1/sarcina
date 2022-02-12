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

    }
}
