using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Calculator.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod()]
        public void AddTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\AddTest.txt");
            AddOperator add = new AddOperator(reader);
            Assert.AreEqual(5, add.Evaluate());
        }

        [TestMethod()]
        public void SubtractTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\SubtractTest.txt");
            SubtractOperator sub = new SubtractOperator(reader);
            Assert.AreEqual(-1, sub.Evaluate());
        }


        [TestMethod()]
        public void MultiplyTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\MultiplyTest.txt");
            SubtractOperator sub = new SubtractOperator(reader);
            Assert.AreEqual(6, sub.Evaluate());
        }
        [TestMethod()]
        public void DivideTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\DivideTest.txt");
            SubtractOperator sub = new SubtractOperator(reader);
            Assert.AreEqual(2, sub.Evaluate());
        }

        [TestMethod()]
        public void NegateTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\NegateTest.txt");
            SubtractOperator sub = new SubtractOperator(reader);
            Assert.AreEqual(-5, sub.Evaluate());
        }

        [TestMethod()]
        public void ExpressionTest1()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\ExpressionTest1.txt");
            AddOperator add = new AddOperator(reader);
            Assert.AreEqual(42, add.Evaluate());
            VerifyToString(add, "2+(8*5)");
        }
        [TestMethod()]
        public void ExpressionTest2()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\ExpressionTest2.txt");
            AddOperator mul = new AddOperator(reader);
            Assert.AreEqual(0, mul.Evaluate());
            VerifyToString(mul, "-(5)+(2+3)");
        }
        [TestMethod()]
        public void ExpressionTest3()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\ExpressionTest3.txt");
            AddOperator mul = new AddOperator(reader);
            Assert.AreEqual(100, mul.Evaluate());
            VerifyToString(mul, "4*Square(-(5))");

        }
        private void VerifyToString(AddOperator add, string verifying)
        {
            if (add.ToString() == verifying)
                Assert.IsTrue(true);
            else if (add.ToString().Substring(1,add.ToString().Length-2) == verifying)
                Assert.IsTrue(true);
            else
                Assert.AreEqual(verifying, add.ToString().Substring(2, add.ToString().Length - 6));
        }
    }
}
