using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElivaatorPro.Manager;
using Moq;
using ElivaatorPro.Manager.Contract;
using ElivaatorPro.Controllers;

namespace FloorTestManager
{
    [TestClass]
    public class UnitTestController
    {
        [TestMethod]
        public void TestSubmitFloor()
        {
            var totalFloor = 80;
            var mockManager = new Mock<IFloorManager>();
            mockManager.Setup(a => a.SetTotalFloor(totalFloor));
            var floorObject = new FloorController(mockManager.Object);
            var actualResult = floorObject.SubmitFloor(totalFloor);

            Assert.AreEqual(actualResult.GetType(), typeof(Microsoft.AspNetCore.Mvc.OkResult));
        }

        [TestMethod]
        public void TestGotoFloorDown()
        {
            SingletonSetLift.instance.SetFloor(80);
            SingletonSetLift.instance.SetCurrentFloor(70);

            var gotoFloor = 4;
            var mockManager = new Mock<IFloorManager>();
            mockManager.Setup(a => a.GotoFloor(gotoFloor)).Returns(ElivaatorPro.Constants.FloorInfo.reachedSelectedFloorDown);
            var floorObject = new FloorController(mockManager.Object);
            var actualResult = floorObject.GotoFloor(gotoFloor);

            Assert.AreEqual(actualResult.GetType(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }

        [TestMethod]
        public void TestGotoFloorUp()
        {
            SingletonSetLift.instance.SetFloor(80);
            SingletonSetLift.instance.SetCurrentFloor(5);

            var gotoFloor = 40;
            var mockManager = new Mock<IFloorManager>();
            mockManager.Setup(a => a.GotoFloor(gotoFloor)).Returns(ElivaatorPro.Constants.FloorInfo.reachedSelectedFloorUp);
            var floorObject = new FloorController(mockManager.Object);
            var actualResult = floorObject.GotoFloor(gotoFloor);

            Assert.AreEqual(actualResult.GetType(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }

        [TestMethod]
        //TODO: incomplete test cases.
        public void TestEvacuate()
        {
            var mockManager = new Mock<IFloorManager>();
            mockManager.Setup(a => a.Evacuate());
            var floorObject = new FloorController(mockManager.Object);

            var actualResult = floorObject.Evacuate();
            var isEvacuation = SingletonSetLift.instance.GetEvacuation();
            Assert.AreEqual(isEvacuation, true);

        }
    }
}

