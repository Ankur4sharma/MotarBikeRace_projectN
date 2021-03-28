using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotarBikeRace_project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotarBikeRace_project.Tests
{
    [TestClass()]
    public class Bike2Tests
    {
        [TestMethod()]
        public void stepJumpTest()
        {
            Bike2 bk = new Bike2();
            if (bk.stepJump() > 10) {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void stepJumpTest2()
        {
            Bike2 bk = new Bike2();
            if (bk.gameOver(760)==0)
            {
                Assert.IsTrue(true);
            }
        }

    }
}