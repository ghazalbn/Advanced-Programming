

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class CarDriverTests
    {
        [TestMethod]
        public void CarDriverInheritedInterfacesTest()
        {
            Assert.IsTrue(typeof(IDriver).IsAssignableFrom(typeof(CarDriver)));
            Assert.IsTrue(typeof(ILocatable).IsAssignableFrom(typeof(CarDriver)));
            Assert.IsTrue(typeof(IPerson).IsAssignableFrom(typeof(CarDriver)));
        }
        [TestMethod]
        public void CarDriverConstructorTest()
        {
            CarDriver cd = new CarDriver("Abbas Salehi", 42, -31, 56, Color.Red);
            Assert.AreEqual(cd.Firstname, "Abbas");
            Assert.AreEqual(cd.Lastname, "Salehi");
            Assert.AreEqual(cd.X + cd.Y + cd.Z, 67);
            Assert.AreEqual(cd.Color, Color.Red);
            Assert.AreEqual(cd.History.Count, 0);
        }
        [TestMethod]
        public void CarDriverVehicleTest()
        {
            CarDriver cd = new CarDriver("Abbas Salehi", 42, -31, 56, Color.Red);
            Assert.AreEqual(cd.VehicleColor(), "Abbas Salehi has a red car!");
        }
        [TestMethod]
        public void CarDriverDistanceTest()
        {
            CarDriver cd = new CarDriver("Sara Eshraghi", 16, -31, 91, Color.White);
            Customer c = new Customer("Mina Akbari", 46, 9, 91);
            Assert.AreEqual(cd.Distance(c), 50);
        }
        [TestMethod]
        public void CarDriverGoToTargetTest()
        {
            CarDriver cd = new CarDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("Azadi Tower", 49, 5, 91);
            cd.GoToTarget(c, target);
            Assert.AreEqual(c.AccountBalance, 35000);
        }
        [TestMethod]
        public void CarDriverLocationTest()
        {
            CarDriver cd = new CarDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("Talar Vahdat", 49, 5, 91);
            cd.GoToTarget(c, target);
            Assert.AreEqual(c.X, 49);
            Assert.AreEqual(c.Y, 5);
            Assert.AreEqual(c.Z, 91);

            Assert.AreEqual(cd.X, 49);
            Assert.AreEqual(cd.Y, 5);
            Assert.AreEqual(cd.Z, 91);
        }
        [TestMethod]
        public void CarDriverExceptionTest()
        {
            CarDriver cd = new CarDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Customer c = new Customer("Dara Heydari", 46, 9, 91, 50000);
            Place target = new Place("Laleh Park", 86, 90, 91);
            try
            {
                cd.GoToTarget(c, target);
                Assert.Fail();
            }
            catch (StackOverflowException s)
            {
                Assert.AreEqual(cd.X, 16);
                Assert.AreEqual(cd.Y, -31);
                Assert.AreEqual(cd.Z, 91);

                Assert.AreEqual(c.X, 46);
                Assert.AreEqual(c.Y, 9);
                Assert.AreEqual(c.Z, 91);

                Assert.AreEqual(c.AccountBalance, 50000);
            }
        }
        [TestMethod]
        public void CarDriverOperatorTest()
        {
            CarDriver cd = new CarDriver("Sadra Khamushi", 16, -31, 91, Color.Gray);
            Place p1 = new Place("Milad Tower", 12, 34, 56);
            Place p2 = new Place("Azadi Tower", 16, 31, 56);
            Traffic t = new Traffic(p1, p2);
            cd = cd + t;
            Assert.AreEqual(cd.History.Count, 1);
            Assert.AreEqual(cd.History[0].source.Name, "Milad Tower");
            Assert.AreEqual(cd.History[0].target.Name, "Azadi Tower");
        }
    }
}
