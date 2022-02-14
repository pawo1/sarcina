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
            map.Update(new VectorObject(-1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[2][1].GameObjects[0], p);
        }

        [TestMethod]
        public void MovePortalBasic()
        {
            Map map = new Map(3, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            Portal x1 = new Portal(new VectorObject(1, 2));
            Portal x2 = new Portal(new VectorObject(2, 1));
            
            map.Grid[1][2].Add(x1);
            map.Grid[2][1].Add(x2);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[2][1].GameObjects[1], p);

            map.Update(new VectorObject(1, 0));
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new VectorObject(0, 1));
            map.Display();

            Assert.AreEqual(map.Grid[2][1].GameObjects[1], p);

            map.Update(new VectorObject(0, 1));
            map.Display();
            map.Update(new VectorObject(0, -1));
            map.Display();

            Assert.AreEqual(map.Grid[1][2].GameObjects[1], p);
        }

        [TestMethod]
        public void MovePortalBoxOnExit()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            Box b = new Box();
            map.Grid[3][1].Add(b);

            Portal x1 = new Portal(new VectorObject(1, 3));
            Portal x2 = new Portal(new VectorObject(2, 1));
            map.Grid[1][2].Add(x1);
            map.Grid[3][1].Add(x2);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            //Assert.AreEqual(map.Grid[3][1].GameObjects[0], x2);
            Assert.AreEqual(map.Grid[3][1].GameObjects[1], p);
            Assert.AreEqual(map.Grid[3][2].GameObjects[0], b);
        }

        [TestMethod]
        public void MoveTerminalButton()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);


            Terminal t = new Terminal();
            Box b = new Box();
            t.AddBox(b);
            map.Grid[3][1].Add(t);

            Button bt = new Button(new VectorObject(1, 3));
            map.Grid[1][2].Add(bt);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[1][2].GameObjects[1], p);
            Assert.AreEqual(map.Grid[3][1].GameObjects[1], b);
        }

        [TestMethod]
        public void MovePortalBoxThrough()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][0].Add(p);

            Box b = new Box();
            map.Grid[1][1].Add(b);

            Portal x1 = new Portal(new VectorObject(1, 3));
            Portal x2 = new Portal(new VectorObject(2, 1));
            map.Grid[1][2].Add(x1);
            map.Grid[3][1].Add(x2);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();
            Assert.AreEqual(map.Grid[3][1].GameObjects[1], b);

            map.Update(new VectorObject(1, 0));
            map.Display();

            //Assert.AreEqual(map.Grid[3][1].GameObjects[0], x2);
            Assert.AreEqual(map.Grid[3][1].GameObjects[1], p);
            Assert.AreEqual(map.Grid[3][2].GameObjects[0], b);
        }

        [TestMethod]
        public void MovePortalBoxPushPass()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            Box b = new Box();
            map.Grid[1][2].Add(b);

            Portal x1 = new Portal(new VectorObject(1, 3));
            Portal x2 = new Portal(new VectorObject(2, 1));
            map.Grid[1][2].Add(x1);
            map.Grid[3][1].Add(x2);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            //Assert.AreEqual(map.Grid[3][1].GameObjects[0], x2);
            Assert.AreEqual(map.Grid[3][1].GameObjects[1], p);
            Assert.AreEqual(map.Grid[1][3].GameObjects[0], b);
        }

        [TestMethod]
        public void MovePortalBoxPushPassobjective()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            Box b = new Box();
            map.Grid[1][2].Add(b);

            Portal x1 = new Portal(new VectorObject(1, 3));
            Portal x2 = new Portal(new VectorObject(2, 1));
            map.Grid[1][2].Add(x1);
            map.Grid[3][1].Add(x2);

            Objective o = new Objective();
            map.Grid[1][3].Add(o);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[3][1].GameObjects[1], p);
            Assert.AreEqual(map.Grid[1][3].GameObjects[1], b);
            Assert.AreEqual(true, map.IsWon());
        }

        [TestMethod]
        public void MovePortalWallOnPortalEntrance()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            Wall w = new Wall();
            map.Grid[1][2].Add(w);

            Portal x1 = new Portal(new VectorObject(1, 3));
            Portal x2 = new Portal(new VectorObject(2, 1));
            map.Grid[1][2].Add(x1);
            map.Grid[3][1].Add(x2);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            //Assert.AreEqual(map.Grid[3][1].GameObjects[0], x2);
            Assert.AreEqual(map.Grid[1][1].GameObjects[0], p);
        }

        [TestMethod]
        public void MovePortalWallOnPortalExit()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            Wall w = new Wall();
            map.Grid[3][1].Add(w);

            Portal x1 = new Portal(new VectorObject(1, 3));
            Portal x2 = new Portal(new VectorObject(2, 1));
            map.Grid[1][2].Add(x1);
            map.Grid[3][1].Add(x2);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            //Assert.AreEqual(map.Grid[3][1].GameObjects[0], x2);
            Assert.AreEqual(map.Grid[1][2].GameObjects[1], p);
        }

        [TestMethod]
        public void MoveTerminalBox()
        {
            Map map = new Map(4, 4);

            Player p = new Player();
            map.Grid[1][1].Add(p);

            Box b = new Box();
            map.Grid[1][2].Add(b);

            Terminal t = new Terminal();
            map.Grid[1][3].Add(t);


            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            //Assert.AreEqual(map.Grid[3][1].GameObjects[0], x2);
            Terminal t2 = (Terminal)map.Grid[1][3].GameObjects[0];
            Assert.AreEqual(t, t2);
            Assert.AreEqual(b, t2.SavedBoxes[0]);
        }

        [TestMethod]
        public void MovePortalBoxPortalBlock()
        {
            Map map = new Map(5, 5);

            var x1apos = new VectorObject(1, 1);
            var x1bpos = new VectorObject(1, 3);
            Portal x1a = new Portal(x1bpos);
            Portal x1b = new Portal(x1apos);
            map.Grid[(int)x1apos.Y][(int)x1apos.X].Add(x1a);
            map.Grid[(int)x1bpos.Y][(int)x1bpos.X].Add(x1b);

            var x2apos = new VectorObject(2, 1);
            var x2bpos = new VectorObject(2, 2);
            Portal x2a = new Portal(x2bpos);
            Portal x2b = new Portal(x2apos);
            map.Grid[(int)x2apos.Y][(int)x2apos.X].Add(x2a);
            map.Grid[(int)x2bpos.Y][(int)x2bpos.X].Add(x2b);

            var x3apos = new VectorObject(2, 3);
            var x3bpos = new VectorObject(2, 4);
            Portal x3a = new Portal(x3bpos);
            Portal x3b = new Portal(x3apos);
            map.Grid[(int)x3apos.Y][(int)x3apos.X].Add(x3a);
            map.Grid[(int)x3bpos.Y][(int)x3bpos.X].Add(x3b);

            Player p = new Player();
            map.Grid[1][0].Add(p);

            var b1 = new Box();
            map.Grid[1][1].Add(b1);

            var b2 = new Box();
            map.Grid[2][2].Add(b2);

            var b3 = new Box();
            map.Grid[3][1].Add(b3);

            map.Display();
            map.Update(new VectorObject(1, 0));
            map.Display();

            Assert.AreEqual(map.Grid[3][1].GameObjects[1], p);
            Assert.AreEqual(map.Grid[1][2].GameObjects[1], b1);
            Assert.AreEqual(map.Grid[2][2].GameObjects[1], b2);
            Assert.AreEqual(map.Grid[4][2].GameObjects[1], b3);
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
            map.Update(new VectorObject(-1, 0));
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
            map.Update(new VectorObject(-1, 0));
            map.Display();
            map.Update(new VectorObject(-1, 0));
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
            map.Update(new VectorObject(0, -1)); // v  [2][1]
            map.Display();
            Assert.AreEqual(map.Grid[2][1].GameObjects[0], p);

            map.Update(new VectorObject(1, 0)); // >  [2][2]
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new VectorObject(0,  1)); // ^  [1][2]
            map.Display();
            Assert.AreEqual(map.Grid[1][2].GameObjects[0], p);

            map.Update(new VectorObject(-1, 0)); // <  [1][1]
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
            map.Update(new VectorObject(0, -1)); // v  [1][0]
            map.Display();
            map.Update(new VectorObject(1,  0)); // >  [1][1]
            map.Display();
            map.Update(new VectorObject(1,  0)); // >  [1][2]
            map.Display();
            map.Update(new VectorObject(1,  0)); // >  [1][2]
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
            map.Update(new VectorObject(0, -1)); // v
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new VectorObject(1, 0)); // >
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new VectorObject(0, 1)); // ^
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            map.Update(new VectorObject(-1, 0)); // <  
            map.Display();
            Assert.AreEqual(map.Grid[2][2].GameObjects[0], p);

            w1.IsWall = false;

            map.Update(new VectorObject(0, 1)); // ^  
            map.Display();
            Assert.AreEqual(map.Grid[1][2].GameObjects[1], p);

            w5.IsWall = true;

            map.Update(new VectorObject(0, 1)); // ^  
            map.Display();
            Assert.AreEqual(map.Grid[0][2].GameObjects[0], p);

            map.Update(new VectorObject(0, -1)); // v  
            map.Display();
            Assert.AreEqual(map.Grid[0][2].GameObjects[0], p);
        }
    }
}
