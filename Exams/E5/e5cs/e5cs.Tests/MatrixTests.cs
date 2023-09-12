using Microsoft.VisualStudio.TestTools.UnitTesting;
using static e5cs.Matrix;

namespace e5cs.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void ConstructorTests()
        {
            Matrix m1 = new Matrix(rows:2,cols:2);
            m1.Data[0,0] = 1;
            m1.Data[0,1] = 2;
            m1.Data[1,0] = 0;
            m1.Data[1,1] = 1;
            int m1_1_1 = m1.Data[1,1];
            Assert.AreEqual(m1_1_1,1);
            // m1[0] = new int[2] {1, 2};
            // m1[1] = new int[2] {0, 1};
            Assert.AreEqual(m1.ColCount,2);
            Assert.AreEqual(m1.RowCount,2);
            Assert.AreEqual(m1.Data[0,0],1);
            Assert.AreEqual(m1.Data[1,1],1);
        
        }

        [TestMethod]
        public void AddOperatorTest()
        {
            Matrix m1 = new Matrix(rows:2,cols:2);
            m1.Data[0,0] = 1;
            m1.Data[0,1] = 2;
            m1.Data[1,0] = 0;
            m1.Data[1,1] = 1;

            Matrix m2 = new Matrix(2,2);
            m2.Data[0,0] = 1;
            m2.Data[0,1] = -1;
            m2.Data[1,0] = 0;
            m2.Data[1,1] = 3;
            Matrix sum = new Matrix(2,2);
            sum.Data[0,0] = 2;
            sum.Data[0,1] = 1;
            sum.Data[1,0] = 0;
            sum.Data[1,1] = 4;
            Matrix mSum = m1 + m2; 
            Assert.AreEqual(m2.ColCount,mSum.ColCount);
            for (int i = 0; i < mSum.RowCount; i++)
            {
               for (int j = 0; j < mSum.RowCount; j++)
                Assert.AreEqual(mSum.Data[i,j],sum.Data[i,j]);
            } 
        }

        [TestMethod]
        public void SingleIndexerTest()
        {
            Matrix m1 = new Matrix(rows:2,cols:2);
            m1[0] = new int[2] {1, 2};
            m1[1] = new int[2] {0, 1};

            Assert.AreEqual(m1.Data[0,0],1);
            Assert.AreEqual(m1.Data[1,1],1);
        }

        [TestMethod]
        public void DoubleIndexerTest()
        {
            Matrix m2 = new Matrix(2,2);
            m2[0,0] = 1; m2[0, 1] = -1;
            m2[1,0] = 0; m2[1, 1] = 3;
            Assert.AreEqual(m2.Data[0,0],1);
            Assert.AreEqual(m2.Data[1,1],3);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionMisMatchException))]
        public void AddOperatorExceptionTest()
        {
         Matrix m1 = new Matrix(rows:2,cols:2);
            m1.Data[0,0] = 1;
            m1.Data[0,1] = 2;
            m1.Data[1,0] = 0;
            m1.Data[1,1] = 1;
            Matrix m2 = new Matrix(rows:1,cols:2);
            m2.Data[0,0] = 1;
            m2.Data[0,1] = 2;
            Matrix mSum = m1 + m2; 
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionMisMatchException))]
        public void MulOperatorExceptionTest()
        {
            Matrix m1 = new Matrix(rows:2,cols:2);
            m1.Data[0,0] = 1;
            m1.Data[0,1] = 2;
            m1.Data[1,0] = 0;
            m1.Data[1,1] = 1;
            Matrix m2 = new Matrix(rows:1,cols:1);
            m2.Data[0,0] = 1;
            Matrix mMul = m1*m2; 
        }
        [TestMethod]
        public void MulOperatorTest()
        {
            Matrix m2 = new Matrix(2,2);
            m2.Data[0,0] = 1;
            m2.Data[0,1] = -1;
            m2.Data[1,0] = 0;
            m2.Data[1,1] = 3;
            Matrix m1 = new Matrix(rows:2,cols:2);
            m1.Data[0,0] = 1;
            m1.Data[0,1] = 2;
            m1.Data[1,0] = 0;
            m1.Data[1,1] = 1;
            Matrix mMul = m1 * m2;
            Matrix mul = new Matrix(2,2);
            mul.Data[0,0] = 1;
            mul.Data[0,1] = 1;
            mul.Data[1,0] = 0;
            mul.Data[1,1] = 3;
            for (int i = 0; i < mMul.RowCount; i++)
            {
               for (int j = 0; j < mMul.RowCount; j++)
                Assert.AreEqual(mMul.Data[i,j],mul.Data[i,j]);
            } 
            
        }


    }
}
