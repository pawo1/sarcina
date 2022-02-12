using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sarcina.Maps;
using Sarcina.Managers;
using Sarcina.Objects;


namespace SarcinaTest
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void RestoreMapTest()
        {
            GameManager manager = new GameManager();
            manager.LoadMap("MapSerial.json");
            foreach(GameObject obj in manager.map.Grid[0][0])
            {
                obj.IsWall = true;
            }
            Player player = new Player();
            Assert.AreEqual(player.IsWall, true);
            manager.RestoreMap();
            Assert.AreEqual(player.IsWall, false);
        }

    }
}
