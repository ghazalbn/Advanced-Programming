using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace A10_cs.Tests
{
    [TestClass]
    public class NotifTests
    {
        [TestMethod]
        public void NotifableConstructor_Test()
        {
            string[] NotifInfo = typeof(Notifable).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(notif => notif.ToString()).ToArray();

            Assert.IsTrue(NotifInfo.Length >= 1);
            Assert.IsTrue(NotifInfo.Contains("System.String Notif(System.String)"));

            Notifable n = new Notifable();
            Assert.AreEqual(n.Messages.Count, 0);
        }
        [TestMethod]
        public void EmailConstructor_Test()
        {
            typeof(Notifable).IsAssignableFrom(typeof(Email));

            Notifable email = new Email();
            Assert.AreEqual(email.Notif("Hello World"), "Sent email : Hello World");
        }
        [TestMethod]
        public void MobileConstructor_Test()
        {
            typeof(Notifable).IsAssignableFrom(typeof(Mobile));

            Notifable mobile = new Mobile();
            Assert.AreEqual(mobile.Notif("Hello World"), "Sent short message : Hello World");
        }
    }
}
