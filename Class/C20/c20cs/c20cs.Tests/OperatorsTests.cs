using OOCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace l29cs.tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void AddOperatorTests()
        {
            var tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new string[]{"3", "4"});
            StreamReader r = new StreamReader(tempFile);            
            AddOperator ao = new AddOperator(r);
            double result = ao.Evaluate();
            Assert.AreEqual(7, result);

            string tostrResult = ao.ToString();
            Assert.AreEqual("(3+4)",tostrResult);
        }
        [TestMethod]
        public void MultipleOperatorTests()
        {
            var tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new string[]{"3", "4"});
            StreamReader r = new StreamReader(tempFile);            
            MultiplyOperator mo = new MultiplyOperator(r);
            double result = mo.Evaluate();
            Assert.AreEqual(12, result);

            string tostrResult = mo.ToString();
            Assert.AreEqual("(3*4)",tostrResult);
        }
        [TestMethod]
        public void MulAddOperatorTests()
        {
            var tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new string[]{
                "Multiply","Add", "3", "4", "Add", "2", "5"});
            StreamReader r = new StreamReader(tempFile);            
            var ao = Expression.BuildExpressionTree(r);
            double result = ao.Evaluate();
            Assert.AreEqual(49, result);

            string tostrResult = ao.ToString();
            Assert.AreEqual("((3+4)*(2+5))",tostrResult);
        }

        [TestMethod]
        public void NumberExpressionTests()
        {     
            var ne = new NumberExpression("3");
            double result = ne.Evaluate();
            Assert.AreEqual(3, result);

            string tostrResult = ne.ToString();
            Assert.AreEqual("3",tostrResult);
        }        
    }
}
