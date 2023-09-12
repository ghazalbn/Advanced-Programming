using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Exam1B.Tests
{
    [TestClass]
    public class GenericMethodTest
    {
        [TestMethod]
        public void ReverseIntTest()
        {
            int[] intArray = new int[5] { 1, 4, 5, 2, 9 };
            int[] expectedInt = new int[5] { 9, 2, 5, 4, 1 };
            CollectionAssert.AreEqual(Program.Reverse(intArray), expectedInt);

        }
        [TestMethod]
        public void ReverseStringTest()
        {
            string[] stringArray = new string[4] { "Have", "A", "Good", "Day" };
            string[] expectedString = new string[4] { "Day", "Good", "A", "Have" };
            CollectionAssert.AreEqual(Program.Reverse(stringArray), expectedString);
        }
    }
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void IPlayerTest()
        {
            PropertyInfo[] type = typeof(IPlayer).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            string[] exp = new string[2] { "Boolean height", "Boolean speed" };
            CollectionAssert.AreEqual(type.Select(d => d.ToString()).ToArray(), exp);

            MethodInfo[] methods = typeof(IPlayer).GetMethods(BindingFlags.Instance | BindingFlags.Public);
            string expMethod = "System.String Post()";
            Assert.IsTrue(methods.Select(d => d.ToString()).ToArray().Contains(expMethod));
        }
        [TestMethod]
        public void AthleteCostructorTest()
        {
            Athlete athlete = new Athlete("Cristiano", true, false);
            Assert.AreEqual(athlete.name, "Cristiano");
            Assert.IsTrue(athlete.height);
            Assert.IsFalse(athlete.speed);
        }
        [TestMethod]
        public void AthletePost()
        {
            Athlete athlete = new Athlete("Kobe", true, true);
            Assert.AreEqual(athlete.Post(), "Kobe is appropriate for basketball");

            athlete = new Athlete("Mozarski", true, false);
            Assert.AreEqual(athlete.Post(), "Mozarski is appropriate for volleyball");

            athlete = new Athlete("Bolt", false, true);
            Assert.AreEqual(athlete.Post(), "Bolt is appropriate for running");

            athlete = new Athlete("Borows", false, false);
            Assert.AreEqual(athlete.Post(), "Borows is appropriate for wrestling");

        }


    }
    [TestClass]
    public class ExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void VowelSound() 
        {
            string s = "salam";
            var t= Program.Vowels(s);
        }
        [TestMethod]
        public void VowelNotFound()
        {
            string s = "slm";
            string result = Program.Vowels(s);
            Assert.AreEqual(result, "Not Found!");
        }
    }
}
