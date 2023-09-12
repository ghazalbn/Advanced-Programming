

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CustomerInheritedInterfacesTest()
        {
            Assert.IsTrue(typeof(ILocatable).IsAssignableFrom(typeof(Customer)));
            Assert.IsTrue(typeof(IPerson).IsAssignableFrom(typeof(Customer)));
        }
        [TestMethod]
        public void CustomerConstructorTest()
        {
            Customer c = new Customer("Mozhgan Sadeghi", 120, 531, 44);
            Assert.AreEqual(c.Firstname, "Mozhgan");
            Assert.AreEqual(c.Lastname, "Sadeghi");
            Assert.AreEqual(c.X , 120);
            Assert.AreEqual(c.Y , 531);
            Assert.AreEqual(c.Z , 44);
            Assert.AreEqual(c.AccountBalance, 0);
            Assert.AreEqual(c.History.Count, 0);
        }
        [TestMethod]
        public void CustomerChargeAccountTest()
        {
            Customer c = new Customer("Reza Moradi", 31, 321, 14, 52000);
            c = c + 5000;
            Assert.AreEqual(c.AccountBalance, 57000);
        }
        [TestMethod]
        public void CustomerDistanceTest()
        {
            Customer c = new Customer("Mozhgan Sadeghi", 91, 531, 90);
            Place p = new Place("Milad Tower", 151, 611, 15);

            Assert.AreEqual(c.Distance(p), 125);
        }
        [TestMethod]
        public void CustomerIEnumerableTest()
        {
            Place[] places = new Place[]
            {
                 new Place("AzadiTower", 49, 5, 191),
                 new Place("MiladTower", 59, 6, 901),
                 new Place("TalarVahdat", 69, 7, 921),
                 new Place("LalehPark", 79, 8, 931)
            };

            Customer c = new Customer("Mozhgan Sadeghi", 91, 531, 90);
            c.History = new List<Traffic>()
            { 
                new Traffic(places[0], places[1]),
                new Traffic(places[3], places[1]),
                new Traffic(places[2], places[0]),
            };
            string[] result = new string[] { "AzadiTower:MiladTower", "LalehPark:MiladTower", "TalarVahdat:AzadiTower" };
            int i = 0;
            foreach (string path in c)
            {
                Assert.AreEqual(result[i], path);
                i++;
            }
        }
    }
}
