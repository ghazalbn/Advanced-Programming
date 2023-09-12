using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Calculator.Tests
{
    [TestClass]
    public class UnitTest2
    {

        [TestMethod()]
        public void AddTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\AddTest.txt");
            Expression add = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(5, add.Evaluate());
        }

        [TestMethod()]
        public void SubtractTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\SubtractTest.txt");
            Expression sub = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(-1, sub.Evaluate());
        }


        [TestMethod()]
        public void MultiplyTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\MultiplyTest.txt");
            Expression sub = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(6, sub.Evaluate());
        }
        [TestMethod()]
        public void DivideTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\DivideTest.txt");
            Expression sub = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(2, sub.Evaluate());
        }

        [TestMethod()]
        public void NegateTest()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\NegateTest.txt");
            Expression sub = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(-5, sub.Evaluate());
        }

        [TestMethod()]
        public void ExpressionTest1()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\ExpressionTest1.txt");
            Expression add = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(42, add.Evaluate());
            Assert.AreEqual(add.ToString(), "(2+(8*5))");
        }
        [TestMethod()]
        public void ExpressionTest2()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\ExpressionTest2.txt");
            Expression mul = Expression.BuildExpressionTree(reader);
        }
        [TestMethod()]
        public void ExpressionTest3()
        {
            StreamReader reader = new StreamReader(@"..\..\..\TestData\ExpressionTest3.txt");
            Expression mul = Expression.BuildExpressionTree(reader);
            Assert.AreEqual(100, mul.Evaluate());
            Assert.AreEqual(mul.ToString(), "(4*Square(-(5)))");
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
