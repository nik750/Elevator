using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElivaatorPro.Manager;

namespace FloorTestManager
{
    [TestClass]
    public class UnitTestManager
    {
        [TestMethod]
        public void TestSetTotalFloor()
        {
            FloorManager fm = new FloorManager();
            var expectedFloor = 10;
            fm.SetTotalFloor(10);
            var actualFloor = SingletonSetLift.instance.GetFloor();
            Assert.AreEqual(expectedFloor, actualFloor);
        }

        [TestMethod]
        public void TestLiftUp()
        {
            SingletonSetLift.instance.SetFloor(10);
            SingletonSetLift.instance.SetCurrentFloor(0);

            FloorManager fm = new FloorManager();
            fm.GotoFloor(5);
            var expectedCurrentFloor = 5;
            var actualCurrentFloor = SingletonSetLift.instance.GetCurrentFloor();
            Assert.AreEqual(expectedCurrentFloor, actualCurrentFloor);
        }

        [TestMethod]
        public void TestLiftDown()
        {
            SingletonSetLift.instance.SetFloor(10);
            SingletonSetLift.instance.SetCurrentFloor(5);

            FloorManager fm = new FloorManager();
            fm.GotoFloor(2);
            var expectedCurrentFloor = 2;
            var actualCurrentFloor = SingletonSetLift.instance.GetCurrentFloor();
            Assert.AreEqual(expectedCurrentFloor, actualCurrentFloor);
        }

        [TestMethod]
        public void TestSameFloor()
        {
            SingletonSetLift.instance.SetFloor(10);
            SingletonSetLift.instance.SetCurrentFloor(5);

            FloorManager fm = new FloorManager();
            fm.GotoFloor(5);
            var expectedCurrentFloor = 5;
            var actualCurrentFloor = SingletonSetLift.instance.GetCurrentFloor();
            Assert.AreEqual(expectedCurrentFloor, actualCurrentFloor);
        }
    }
}
