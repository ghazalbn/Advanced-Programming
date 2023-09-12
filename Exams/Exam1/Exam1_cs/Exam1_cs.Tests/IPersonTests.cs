

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Exam1_cs.Tests
{
    [TestClass]
    public class IPersonTests
    {
        [TestMethod]
        public void IPersonPropertyTest()
        {
            PropertyInfo[] type = typeof(IPerson).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            string[] expProperties = new string[] { "System.String Firstname", "System.String Lastname" };
            string[] res = type.Select(d => d.ToString()).ToArray();
            foreach (string property in expProperties)
                Assert.IsTrue(res.Contains(property));
        }
    }
}
