using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Runtime.Serialization;
using System.Text.Json;
using System.IO;

using Sarcina.Objects;
using Sarcina.Maps;

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
