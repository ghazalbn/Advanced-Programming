

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class TrafficTests
    {
        [TestMethod]
        public void TrafficConstructorTest()
        {
            Place p1 = new Place("Milad Tower", 12, 34, 56);
            Place p2 = new Place("Azadi Tower", 16, 31, 56);
            Traffic t = new Traffic(p1, p2);

            Assert.AreEqual(t.source.X + t.target.X, 28);
            Assert.AreEqual(t.source.Y + t.target.Y, 65);
            Assert.AreEqual(t.source.Z + t.target.Z, 112);
        }
    }
}
