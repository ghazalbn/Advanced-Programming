using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e6cs.Tests
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void VectorIComparableInterfaceTest()
        {
            Vector[] vectors = new Vector[]{
                new Vector(5, 3, 2),
                new Vector(1, 10, 10),
                new Vector(1, 0, 1),
                new Vector(4, 3, 2)
            };

            Array.Sort(vectors); // CallCount to CompareTo = 6

            for(int i=1; i<vectors.Length; i++)
            {
                Assert.IsTrue(vectors[i].Magnitude >= vectors[i-1].Magnitude);
            }

            vectors[2][1] = 40;

            Array.Sort(vectors); // CallCount to CompareTo = 4

            for(int i=1; i<vectors.Length; i++)
            {
                Assert.IsTrue(vectors[i].Magnitude >= vectors[i-1].Magnitude);
            }


        }

        [TestMethod]
        public void VectorIEquatableInterfaceTest()
        {
            List<Vector> vecList = new List<Vector>() {
                new Vector(5, 3, 2),
                new Vector(1, 10, 10),
                new Vector(1, 0, 1),
                new Vector(4, 3, 2)
            };

            Assert.IsTrue(vecList.Contains(new Vector(1, 0, 1))); // CallCount to Equals = 3
            Assert.IsTrue(vecList.Contains(new Vector(4, 3, 2))); // CallCount to Equals = 4

            Assert.IsFalse(vecList.Contains(new Vector(0, 0, 0))); // CallCount to Equals = 4
            Assert.IsFalse(vecList.Contains(new Vector(1, 1)));    // CallCount to Equals = 4

            Assert.AreEqual(vecList.IndexOf(new Vector(1,0,1)), 2); // CallCount to Equals = 3
            Assert.AreEqual(vecList.IndexOf(new Vector(5,3,2)), 0); // CallCount to Equals = 1
        }        
    }
}
