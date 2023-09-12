

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class IDriverTests
    {
        [TestMethod]
        public void IDriverPropertyTest()
        {
            PropertyInfo[] type = typeof(IDriver).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            string[] expProperties = new string[] { "System.Drawing.Color Color"};
            string[] res = type.Select(d => d.ToString()).ToArray();
            foreach (string property in expProperties)
                Assert.IsTrue(res.Contains(property));
        }
        [TestMethod]
        public void IDriverMethodTest()
        {
            MethodInfo[] methods = typeof(IDriver).GetMethods(BindingFlags.Instance | BindingFlags.Public);
            string expMethod = "Void GoToTarget(Exam1_cs.Customer, Exam1_cs.ILocatable)";
            Assert.IsTrue(methods.Select(d => d.ToString()).ToArray().Contains(expMethod));
        }
    }
}
