using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A10_cs.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonConstructor_Test()
        {
            Person p1 = new Person("Rira Ashoobi", Gender.Female);
            Assert.AreEqual(p1.name, "Ms.Rira Ashoobi");

            Person p2 = new Person("Pedram Arzani", Gender.Male);
            Assert.AreEqual(p2.name, "Mr.Pedram Arzani");
        }
        [TestMethod]
        public void PersonPrint_Test()
        {
            Person p = new Person("Pedram Arzani", Gender.Male);
            Assert.AreEqual(p.Print(), "Mr.Pedram Arzani");
        }
    }
}
