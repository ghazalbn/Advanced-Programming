using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam2.Tests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void MatrixConstructor()
        {
            int m = 2;
            int n = 3;
            int[,] values = new int[,] {
                {1,2,3},
                {4,5,6}
            };
            Matrix matrix = new Matrix(m, n, values);
            Assert.AreEqual(matrix[0, 0], 1);
            Assert.AreEqual(matrix[0, 1], 2);
            Assert.AreEqual(matrix[0, 2], 3);
            Assert.AreEqual(matrix[1, 0], 4);
            Assert.AreEqual(matrix[1, 1], 5);
            Assert.AreEqual(matrix[1, 2], 6);
        }
        [TestMethod]
        public void AddTest()
        {
            Assert.Inconclusive();
            int m1 = 2;
            int n1 = 3;
            int[,] values1 = new int[,] {
                {1,2,3},
                {4,5,6}
            };
            Matrix a = new Matrix(m1, n1, values1);

            int m2 = 2;
            int n2 = 3;
            int[,] values2 = new int[,] {
                {10,20,30},
                {40,50,60}
            };
            Matrix b = new Matrix(m2, n2, values2);

            Matrix added = a.AddMatrix(b).Result;
            Assert.AreEqual(added.M, 2);
            Assert.AreEqual(added.N, 3);
            int[,] res = new int[,] {
                {11,22,33},
                {44,55,66}
            };
            CollectionAssert.AreEqual(added.Numbers, res);
        }
        [TestMethod]
        public void MultiplyTest()
        {
            Assert.Inconclusive();
            int m1 = 2;
            int n1 = 3;
            int[,] values1 = new int[,] {
                {1,2,3},
                {4,5,6}
            };
            Matrix a = new Matrix(m1, n1, values1);

            int m2 = 3;
            int n2 = 2;
            int[,] values2 = new int[,] {
                {1,2},
                {3,4},
                {5,6}
            };
            Matrix b = new Matrix(m2, n2, values2);

            Matrix mul = a.MultiplyMatrix(b);
            Assert.AreEqual(mul.M, 2);
            Assert.AreEqual(mul.N, 2);
            int[,] res = new int[,] {
                {22,28},
                {49,64}
            };
            CollectionAssert.AreEqual(mul.Numbers, res);
        }
        [TestMethod]
        public void ExplicitOperatorTest()
        {
            int[,] values2 = new int[,] {
                {1,2},
                {3,4},
                {5,6}
            };
            // Your Program Should Handle This Line
            Matrix s1 = (Matrix)values2;
            CollectionAssert.AreEqual(s1.Numbers, values2);
        }
        [TestMethod()]
        public void ReverseExplicitOperatorTest()
        {
            int[,] values1 = new int[,] {
                {1,2},
                {3,4},
                {5,6}
            };
            Matrix s1 = new Matrix(3,2,values1);
            // Your Program Should Handle This Line
            int[,] ss1 = (int[,])s1;
            int[,] values2 = new int[,] {
                {2,4},
                {6,8},
                {10,12}
            };
            CollectionAssert.AreEqual(ss1, values2);
        }
        [TestMethod()]
        public void MatrixToStringTest()
        {
            int[,] values1 = new int[,] {
                {1,2},
                {3,4},
                {5,6}
            };
            Matrix s1 = new Matrix(3, 2, values1);
            Assert.AreEqual(s1.ToString(), "1 2 3 4 5 6");
        }
    }
}
