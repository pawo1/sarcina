using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Runtime.Serialization;
using System.Text.Json;
using System.IO;
using Sarcina.Maps;
using System.Diagnostics;

using Sarcina.Objects;
using Sarcina.Maps;
using System;
using System.Numerics;

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

            map.Grid[2][2] = new Field();
            Player p = new Player();
            map.Grid[2][2].Add(p);
            map.Display();
            map.Update(new Vector2(-1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[2][1].GameObjects[0], p);
        }

        [TestMethod]
        public void MovePlayers()
        {
            Map map = new Map(3, 4);

            map.Grid[2][2] = new Field();
            Player p = new Player();
            map.Grid[2][2].Add(p);

            Player p2 = new Player();
            map.Grid[0][0].Add(p2);

            Player p3 = new Player();
            map.Grid[2][3].Add(p3);

            map.Display();
            map.Update(new Vector2(-1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[2][1].GameObjects[0], p);
            Assert.AreEqual(map.Grid[0][0].GameObjects[0], p2);
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p3);
        }

        [TestMethod]
        public void MovePlayersWithObjects()
        {
            Map map = new Map(3, 4);

            map.Grid[2][2] = new Field();
            Player p = new Player();
            p.Field = 3;

            map.Grid[2][2].Add(p);
            Box b = new Box(123, false);

            b.Field = 5;

            map.Grid[2][1].Add(b);


            Player p2 = new Player();
            map.Grid[0][0].Add(p2);

            map.Display();
            map.Update(new Vector2(-1, 0));
            map.Display();
            map.Update(new Vector2(-1, 0));
            map.Display();

           /* map.Update(new Vector2(1, 0));
            map.Update(new Vector2(1, 0));
            map.Update(new Vector2(1, 0));
            map.Update(new Vector2(1, 0));
            map.Display();*/

            Assert.AreEqual(map.Grid[2][1].GameObjects[0], p);
            Assert.AreEqual(map.Grid[2][0].GameObjects[0], b);
            Assert.AreEqual(map.Grid[0][0].GameObjects[0], p2);
        }
    }
}
