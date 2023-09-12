using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exam2.Tests
{
    [TestClass]
    public class InheritanceTest
    {
        public class ProgrammerTemp : Programmer
        {
            public ProgrammerTemp(string name, bool isFemale) : base(name, isFemale)
            {
            }

            public override int Salary => 0;
        }
        [TestMethod]
        public void ProgrammerTest()
        {
            // Programmer should be an abstract class
            Assert.IsTrue(typeof(Programmer).IsAbstract);

            // It should not have an empty constructor
            Assert.IsTrue(typeof(Programmer).GetConstructor(Type.EmptyTypes) == null);

            Programmer p = new ProgrammerTemp("سارا محمودی", true);
            Assert.AreEqual(p.Name, "خانم سارا محمودی");
            Assert.AreEqual(p.IsFemale, true);
        }
        [TestMethod]
        public void SeniorTest()
        {
            // It should not have an empty constructor
            Assert.IsTrue(typeof(Senior).GetConstructor(Type.EmptyTypes) == null);
            // It should inherit from Programmer
            Assert.IsTrue(typeof(Programmer).IsAssignableFrom(typeof(Senior)));

            Programmer p = new Senior("غزاله عباسی", true);
            Assert.AreEqual(p.Name, "خانم غزاله عباسی");
            Assert.AreEqual(p.IsFemale, true);
            Assert.AreEqual(p.Salary, 4_500_000);

            Assert.AreEqual((p as Senior).CalculateSalary(10), 5_000_000);

            // Student should not override/modify the Name get property.
            Assert.AreNotEqual(
                typeof(Senior).GetMethod("get_Name").DeclaringType,
                typeof(Senior));
        }
        [TestMethod]
        public void JuniorTest()
        {
            // It should not have an empty constructor
            Assert.IsTrue(typeof(Junior).GetConstructor(Type.EmptyTypes) == null);
            // It should inherit from Programmer
            Assert.IsTrue(typeof(Programmer).IsAssignableFrom(typeof(Junior)));

            Programmer p = new Junior("امین قسوری", false);
            Assert.AreEqual(p.Name, "آقای امین قسوری");
            Assert.AreEqual(p.IsFemale, false);
            Assert.AreEqual(p.Salary, 2_800_000);

            // Student should not override/modify the Name get property.
            Assert.AreNotEqual(
                typeof(Junior).GetMethod("get_Name").DeclaringType,
                typeof(Junior));
        }
        [TestMethod]
        public void FullStackTest()
        {
            // It should not have an empty constructor
            Assert.IsTrue(typeof(FullStack).GetConstructor(Type.EmptyTypes) == null);
            // It should inherit from Programmer
            Assert.IsTrue(typeof(Senior).IsAssignableFrom(typeof(FullStack)));

            Programmer p = new FullStack("پارمیس علایی", true);
            Assert.AreEqual(p.Name, "دکتر پارمیس علایی");
            Assert.AreEqual(p.IsFemale, true);
            Assert.AreEqual(p.Salary, 7_500_000);

            Assert.AreEqual((p as FullStack).CalculateSalary(10), 8_200_000);
            Assert.AreEqual((p as Senior).CalculateSalary(10), 8_200_000);

        }
    }
}
