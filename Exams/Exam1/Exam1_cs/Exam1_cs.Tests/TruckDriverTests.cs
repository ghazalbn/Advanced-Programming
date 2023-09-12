

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class TruckDriverTests
    {
        [TestMethod]
        public void MotorCycleInheritedInterfacesTest()
        {
            Assert.IsTrue(typeof(IDriver).IsAssignableFrom(typeof(TruckDriver)));
            Assert.IsTrue(typeof(ILocatable).IsAssignableFrom(typeof(TruckDriver)));
            Assert.IsTrue(typeof(IPerson).IsAssignableFrom(typeof(TruckDriver)));
        }
        [TestMethod]
        public void MotorCycleConstructorTest()
        {
            TruckDriver td = new TruckDriver("Abbas Salehi", 42, -31, 56, Color.Red);
            Assert.AreEqual(td.Firstname, "Abbas");
            Assert.AreEqual(td.Lastname, "Salehi");
            Assert.AreEqual(td.X + td.Y + td.Z, 67);
            Assert.AreEqual(td.Color, Color.Red);
            Assert.AreEqual(td.History.Count, 0);
        }
        [TestMethod]
        public void TruckDriverVehicleTest()
        {
            TruckDriver td = new TruckDriver("Abbas Salehi", 42, -31, 56, Color.White);
            Assert.AreEqual(td.VehicleColor(), "Abbas Salehi has a white truck!");
        }
        [TestMethod]
        public void MotorCycleDistanceTest()
        {
            TruckDriver td = new TruckDriver("Sara Eshraghi", 16, -31, 91, Color.White);
            Customer c = new Customer("Mina Akbari", 46, 9, 91);
            Assert.AreEqual(td.Distance(c), 50);
        }
        [TestMethod]
        public void MotorCycleGoToTargetTest()
        {
            TruckDriver td = new TruckDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("IUST", 49, 5, 91);
            td.GoToTarget(c, target);
            Assert.AreEqual(c.AccountBalance, 14000);
        }
        [TestMethod]
        public void MotorCycleLocationTest()
        {
            TruckDriver td = new TruckDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("SUT University", 49, 5, 91);
            td.GoToTarget(c, target);
            Assert.AreEqual(c.X, 49);
            Assert.AreEqual(c.Y, 5);
            Assert.AreEqual(c.Z, 91);

            Assert.AreEqual(td.X, 49);
            Assert.AreEqual(td.Y, 5);
            Assert.AreEqual(td.Z, 91);
        }
        [TestMethod]
        public void MotorCycleExceptionTest()
        {
            TruckDriver td = new TruckDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("Milad Tower", 86, 90, 91);
            try
            {
                td.GoToTarget(c, target);
                Assert.Fail();
            }
            catch (StackOverflowException s)
            {
                Assert.AreEqual(td.X, 16);
                Assert.AreEqual(td.Y, -31);
                Assert.AreEqual(td.Z, 91);

                Assert.AreEqual(c.X, 46);
                Assert.AreEqual(c.Y, 9);
                Assert.AreEqual(c.Z, 91);

                Assert.AreEqual(c.AccountBalance, 50000);
            }
        }
    }
}
