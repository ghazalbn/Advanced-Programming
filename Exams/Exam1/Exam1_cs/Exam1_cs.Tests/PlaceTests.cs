

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class PlaceTests
    {
        [TestMethod]
        public void PlaceInheritedTest()
        {
            Assert.IsTrue(typeof(ILocatable).IsAssignableFrom(typeof(Place)));
        }
        [TestMethod]
        public void PlaceConstructorTest()
        {
            Place p = new Place("Milad Tower", 12, 34, 56);
            Assert.AreEqual(p.Name, "Milad Tower");
            Assert.AreEqual(p.X, 12);
            Assert.AreEqual(p.Y, 34);
            Assert.AreEqual(p.Z, 56);
        }
        [TestMethod]
        public void PlaceDistanceTest()
        {
            Place p1 = new Place("Milad Tower", 12, 34, 56);
            Place p2 = new Place("Azadi Tower", 16, 31, 56);
            Assert.AreEqual(p1.Distance(p2), p2.Distance(p1));
            Assert.AreEqual(p1.Distance(p2), 5);
        }

    }
}
