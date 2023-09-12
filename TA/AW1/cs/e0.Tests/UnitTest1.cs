using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e0.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(e0.Program.solve("R"),0);
            Assert.AreEqual(e0.Program.solve("L"),0);
            Assert.AreEqual(e0.Program.solve("LR"),0);
            Assert.AreEqual(e0.Program.solve("RL"),1);
            Assert.AreEqual(e0.Program.solve("RLLLL"),4);
            Assert.AreEqual(e0.Program.solve("RRRRR"),0);
            Assert.AreEqual(e0.Program.solve("LLLLL"),0);
            Assert.AreEqual(e0.Program.solve("RLRRL"),3);
            Assert.AreEqual(e0.Program.solve("LRLRLLLLLRLRLLLL"),11);
            Assert.AreEqual(e0.Program.solve("RLLLR"),3);
        }
    }
}

