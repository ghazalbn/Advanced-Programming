

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class MotorCycleDriverTests
    {
        [TestMethod]
        public void MotorCycleInheritedInterfacesTest()
        {
            Assert.IsTrue(typeof(IDriver).IsAssignableFrom(typeof(MotorCycleDriver)));
            Assert.IsTrue(typeof(ILocatable).IsAssignableFrom(typeof(MotorCycleDriver)));
            Assert.IsTrue(typeof(IPerson).IsAssignableFrom(typeof(MotorCycleDriver)));
        }
        [TestMethod]
        public void MotorCycleConstructorTest()
        {
            MotorCycleDriver mcd = new MotorCycleDriver("Abbas Salehi", 42, -31, 56, Color.Red);
            Assert.AreEqual(mcd.Firstname, "Abbas");
            Assert.AreEqual(mcd.Lastname, "Salehi");
            Assert.AreEqual(mcd.X + mcd.Y + mcd.Z, 67);
            Assert.AreEqual(mcd.Color, Color.Red);
            Assert.AreEqual(mcd.History.Count, 0);
        }
        [TestMethod]
        public void MotorCycleVehicleTest()
        {
            MotorCycleDriver mcd = new MotorCycleDriver("Abbas Salehi", 42, -31, 56, Color.Blue);
            Assert.AreEqual(mcd.VehicleColor(), "Abbas Salehi has a blue motor cycle!");
        }
        [TestMethod]
        public void MotorCycleDistanceTest()
        {
            MotorCycleDriver mcd = new MotorCycleDriver("Sara Eshraghi", 16, -31, 91, Color.White);
            Customer c = new Customer("Mina Akbari", 46, 9, 91);
            Assert.AreEqual(mcd.Distance(c), 50);
        }
        [TestMethod]
        public void MotorCycleGoToTargetTest()
        {
            MotorCycleDriver mcd = new MotorCycleDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("Mooze Ebrat", 49, 5, 91);
            mcd.GoToTarget(c, target);
            Assert.AreEqual(c.AccountBalance, 32500);
        }
        [TestMethod]
        public void MotorCycleLocationTest()
        {
            MotorCycleDriver mcd = new MotorCycleDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("Theater", 49, 5, 91);
            mcd.GoToTarget(c, target);
            Assert.AreEqual(c.X, 49);
            Assert.AreEqual(c.Y, 5);
            Assert.AreEqual(c.Z, 91);

            Assert.AreEqual(mcd.X, 49);
            Assert.AreEqual(mcd.Y, 5);
            Assert.AreEqual(mcd.Z, 91);
        }
        [TestMethod]
        public void MotorCycleExceptionTest()
        {
            MotorCycleDriver mcd = new MotorCycleDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("IUST", 86, 90, 91);
            try
            {
                mcd.GoToTarget(c, target);
                Assert.Fail();
            }
            catch (StackOverflowException s)
            {
                Assert.AreEqual(mcd.X, 16);
                Assert.AreEqual(mcd.Y, -31);
                Assert.AreEqual(mcd.Z, 91);

                Assert.AreEqual(c.X, 46);
                Assert.AreEqual(c.Y, 9);
                Assert.AreEqual(c.Z, 91);

                Assert.AreEqual(c.AccountBalance, 50000);
            }
        }
    }
}
