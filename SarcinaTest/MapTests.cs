using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Runtime.Serialization;
using System.Text.Json;
using System.IO;
using Sarcina.Maps;
using System.Diagnostics;

using Sarcina.Objects;
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
            p.SpriteId = 3;

            map.Grid[2][2].Add(p);
            Box b = new Box(123);
            b.SpriteId = 5;

            map.Grid[2][1].Add(b);


            Player p2 = new Player();
            map.Grid[0][0].Add(p2);

            map.Display();
            map.Update(new Vector2(-1, 0));
            map.Display();
            map.Update(new Vector2(-1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[2][1].GameObjects[0], p);
            Assert.AreEqual(map.Grid[2][0].GameObjects[0], b);
            Assert.AreEqual(map.Grid[0][0].GameObjects[0], p2);
        }

        [TestMethod]
        public void MoveAround()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            map.Display();
            map.Update(new Vector2(0, -1)); // v  [2][1]
            map.Display();
            Assert.AreEqual(map.Grid[2][1].GameObjects[0], p);

            map.Update(new Vector2(1, 0)); // >  [2][2]
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new Vector2(0,  1)); // ^  [1][2]
            map.Display();
            Assert.AreEqual(map.Grid[1][2].GameObjects[0], p);

            map.Update(new Vector2(-1, 0)); // <  [1][1]
            map.Display();
            Assert.AreEqual(map.Grid[1][1].GameObjects[0], p);
        }

        [TestMethod]
        public void MoveBoxToWall()
        {
            Map map = new Map(3, 6);

            Player p = new Player();
            map.Grid[0][0].Add(p);

            Box b = new Box();
            map.Grid[1][2].Add(b);

            Wall w = new Wall();
            map.Grid[1][4].Add(w);

            map.Display();
            map.Update(new Vector2(0, -1)); // v  [1][0]
            map.Display();
            map.Update(new Vector2(1,  0)); // >  [1][1]
            map.Display();
            map.Update(new Vector2(1,  0)); // >  [1][2]
            map.Display();
            map.Update(new Vector2(1,  0)); // >  [1][2]
            map.Display();

            Assert.AreEqual(map.Grid[1][2].GameObjects[0], p);
            Assert.AreEqual(map.Grid[1][3].GameObjects[0], b);
            Assert.AreEqual(map.Grid[1][4].GameObjects[0], w);
        }

        [TestMethod]
        public void MoveInWalls()
        {
            Map map = new Map(5, 5);

            Player p = new Player();
            map.Grid[2][2].Add(p);

            Wall w1 = new Wall();
            map.Grid[1][2].Add(w1);
            Wall w2 = new Wall();
            map.Grid[2][1].Add(w2);
            Wall w3 = new Wall();
            map.Grid[2][2].Add(w3);
            Wall w4 = new Wall();
            map.Grid[2][3].Add(w4);
            Wall w5 = new Wall();
            map.Grid[3][2].Add(w5);

            map.Display();
            map.Update(new Vector2(0, -1)); // v
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new Vector2(1, 0)); // >
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new Vector2(0, 1)); // ^
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new Vector2(-1, 0)); // <  
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            w1.IsWall = false;

            map.Update(new Vector2(0, 1)); // ^  
            map.Display();
            Assert.AreEqual(map.Grid[1][2].GameObjects[1], p);

            w5.IsWall = true;

            map.Update(new Vector2(0, 1)); // ^  
            map.Display();
            Assert.AreEqual(map.Grid[0][2].GameObjects[0], p);

            map.Update(new Vector2(0, -1)); // v  
            map.Display();
            Assert.AreEqual(map.Grid[0][2].GameObjects[0], p);
        }
    }
}
