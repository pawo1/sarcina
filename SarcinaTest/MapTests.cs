using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sarcina.Objects;
using System.Runtime.Serialization;
using System.Text.Json;
using System.IO;
using Sarcina.Maps;
using System.Diagnostics;

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
        public void UpdateMap()
        {
            Map map = new Map(3, 4);
            Debug.WriteLine("Down:");
            map.Update(new System.Numerics.Vector2(0, -1));
            Debug.WriteLine("Up:");
            map.Update(new System.Numerics.Vector2(0, 1));
            Debug.WriteLine("Right:");
            map.Update(new System.Numerics.Vector2(1, 0));
            Debug.WriteLine("Down:");
            map.Update(new System.Numerics.Vector2(-1, 0));


        }
    }
}
