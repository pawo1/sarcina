using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Runtime.Serialization;
using System.Text.Json;
using System.IO;
using Sarcina.Maps;
using System.Diagnostics;

using Sarcina.Objects;
using Sarcina.Maps;
using System;

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
        public void MovePlayer()
        {
            Map map = new Map(3, 4);

            map.Grid[2, 2] = new Field();
            Player p = new Player();
            map.Grid[2, 2].Add(p);
            map.Update(new System.Numerics.Vector2(-1, 0));

            Assert.AreEqual(map.Grid[1, 2].GameObjects[0], p);
        }

        [TestMethod]
        public void MovePlayers()
        {
            Map map = new Map(3, 4);

            map.Grid[2, 2] = new Field();
            Player p = new Player();
            map.Grid[2, 2].Add(p);

            Player p2 = new Player();
            map.Grid[0, 0].Add(p2);

            map.Update(new System.Numerics.Vector2(-1, 0));

            Assert.AreEqual(map.Grid[1, 2].GameObjects[0], p);
            Assert.AreEqual(map.Grid[0, 0].GameObjects[0], p2);
        }

        [TestMethod]
        public void MovePlayersWithObjects()
        {
            Map map = new Map(3, 4);

            map.Grid[2, 2] = new Field();
            Player p = new Player();
            map.Grid[2, 2].Add(p);

            Player p2 = new Player();
            map.Grid[0, 0].Add(p2);

            map.Update(new System.Numerics.Vector2(-1, 0));

            Assert.AreEqual(map.Grid[1, 2].GameObjects[0], p);
            Assert.AreEqual(map.Grid[0, 0].GameObjects[0], p2);
        }
    }
}
