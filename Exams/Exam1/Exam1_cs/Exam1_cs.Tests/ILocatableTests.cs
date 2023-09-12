

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class ILocatableTests
    {
        [TestMethod]
        public void ILocatablePropertyTest()
        {
            PropertyInfo[] type = typeof(ILocatable).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            string[] expProperties = new string[] { "Int64 X", "Int64 Y", "Int64 Z" };
            string[] res = type.Select(d => d.ToString()).ToArray();
            foreach (string property in expProperties)
                Assert.IsTrue(res.Contains(property));
        }
        [TestMethod]
        public void ILocatableMethodTest()
        {
            MethodInfo[] methods = typeof(ILocatable).GetMethods(BindingFlags.Instance | BindingFlags.Public);
            string expMethod = "Int64 Distance(Exam1_cs.ILocatable)";
            Assert.IsTrue(methods.Select(d => d.ToString()).ToArray().Contains(expMethod));
        }
    }
}
