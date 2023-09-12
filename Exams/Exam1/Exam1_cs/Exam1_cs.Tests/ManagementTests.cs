

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace Exam1_cs.Tests
{

    [TestClass]
    public class ManagementTests
    {

        [TestMethod]
        public void SortCarDriversTest()
        {
            ManagementDrivers<CarDriver> m = new ManagementDrivers<CarDriver>();

            Place[] places = new Place[]
            {
                new Place("Talar Vahdat",23,45,67),
                new Place("Azadi Tower",11,435,667),
                new Place("Milad Tower",99,88,77),
                new Place("Laleh park",5,54,6767)
            };
            Traffic[] traffics = new Traffic[]
            {
                new Traffic(places[0],places[1]),
                new Traffic(places[2],places[3]),
                new Traffic(places[0],places[3]),
                new Traffic(places[1],places[2])
            };

            m.Drivers = new CarDriver[]
            {
                new CarDriver("Hasan Mohammadi",12,34,56,Color.BlanchedAlmond),
                new CarDriver("Ali Rezaei",433,23,31,Color.Black),
                new CarDriver("Sajad Mashhadi",98,67,896,Color.Yellow),
                new CarDriver("Zahra Harati",77,66,576,Color.Purple),
            };
            m.Drivers[0].History = new List<Traffic>() { traffics[0], traffics[1] };
            m.Drivers[1].History = new List<Traffic>() { traffics[0] };
            m.Drivers[2].History = new List<Traffic>() { traffics[0], traffics[1], traffics[2], traffics[3] };
            m.Drivers[3].History = new List<Traffic>() { traffics[0], traffics[1], traffics[2] };

            m.SortDrivers();

            Assert.AreEqual(m.Drivers[0].Firstname, "Ali");
            Assert.AreEqual(m.Drivers[1].Firstname, "Hasan");
            Assert.AreEqual(m.Drivers[2].Firstname, "Zahra");
            Assert.AreEqual(m.Drivers[3].Firstname, "Sajad");
        }
        [TestMethod]
        public void SortTruckDriversTest()
        {
            ManagementDrivers<TruckDriver> m = new ManagementDrivers<TruckDriver>();

            m.Drivers = new TruckDriver[]
            {
                new TruckDriver("Hasan Mohammadi",12,34,56,Color.BlanchedAlmond),
                new TruckDriver("Ali Rezaei",433,23,31,Color.Black),
                new TruckDriver("Sajad Mashhadi",98,67,896,Color.Yellow),
                new TruckDriver("Zahra Harati",77,66,576,Color.Purple),
            };

            m.SortDrivers();

            Assert.AreEqual(m.Drivers[0].Lastname, "Rezaei");
            Assert.AreEqual(m.Drivers[1].Lastname, "Mohammadi");
            Assert.AreEqual(m.Drivers[2].Lastname, "Mashhadi");
            Assert.AreEqual(m.Drivers[3].Lastname, "Harati");
        }
        [TestMethod]
        public void SortMotorCycleDriversTest()
        {
            ManagementDrivers<MotorCycleDriver> m = new ManagementDrivers<MotorCycleDriver>();

            m.Drivers = new MotorCycleDriver[]
            {
                new MotorCycleDriver("Hasan Mohammadi",12,34,56,Color.BlanchedAlmond),
                new MotorCycleDriver("Ali Rezaei",433,23,31,Color.Black),
                new MotorCycleDriver("Sajad Mashhadi",98,67,896,Color.Yellow),
                new MotorCycleDriver("Zahra Harati",77,66,576,Color.Purple),
            };

            m.SortDrivers();

            Assert.AreEqual(m.Drivers[0].Firstname, "Zahra");
            Assert.AreEqual(m.Drivers[1].Firstname, "Sajad");
            Assert.AreEqual(m.Drivers[2].Firstname, "Hasan");
            Assert.AreEqual(m.Drivers[3].Firstname, "Ali");
        }
        [TestMethod]
        public void WhereIsDriversTest()
        {
            ManagementDrivers<TruckDriver> m = new ManagementDrivers<TruckDriver>();

            m.Drivers = new TruckDriver[]
            {
                new TruckDriver("Hasan Mohammadi",12,34,56,Color.BlanchedAlmond),
                new TruckDriver("Ali Rezaei",433,23,31,Color.Black),
                new TruckDriver("Sajad Mashhadi",98,67,896,Color.Yellow),
                new TruckDriver("Zahra Harati",77,66,576,Color.Purple),
            };
            string[] exp = new string[]
            {
                "Hasan is on 12 situation.",
                "Ali is on 433 situation.",
                "Sajad is on 98 situation.",
                "Zahra is on 77 situation."
            };
            CollectionAssert.AreEqual(m.WhereIsNow(), exp);
        }
        [TestMethod]
        public void NearestTest()
        {
            ManagementDrivers<TruckDriver> m = new ManagementDrivers<TruckDriver>();

            m.Drivers = new TruckDriver[]
            {
                new TruckDriver("Hasan Mohammadi",12,34,56,Color.BlanchedAlmond),
                new TruckDriver("Ali Rezaei",433,23,31,Color.Black),
                new TruckDriver("Sajad Mashhadi",98,67,896,Color.Yellow),
                new TruckDriver("Zahra Harati",77,66,576,Color.Purple),
            };
            Customer c = new Customer("Marzieh Zakeri", 76, 65, 576, 100000);
            Place p = new Place("Laleh Park", 80, 65, 580);

            m.NearestDriver(c, p);
            Assert.AreEqual(c.AccountBalance, 64000);
        }
    }
}
