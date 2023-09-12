using Microsoft.VisualStudio.TestTools.UnitTesting;
using cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void LetTest()
        {
            int a;
            int b = 11;
            Program.Let(out a, ref b);
            Assert.AreEqual(a, 11);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int a = 11;
            Program.Square(ref a);
            Assert.AreEqual(a, 121);
        }

        [TestMethod()]
        public void SwapTest()
        {
            int a = 11;
            int b = 23;
            Program.Swap(ref a, ref b);
            Assert.AreEqual(a, 23);
            Assert.AreEqual(b, 11);
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] a = new int[5] { 1, 5, 6, 7, 2 };
            int[] b = new int[5] { 3, 25, 31, 24, 6 };
            Program.SwapArray(a, b);
            CollectionAssert.AreEqual(a, new int[5] { 3, 25, 31, 24, 6 });
            CollectionAssert.AreEqual(b, new int[5] { 1, 5, 6, 7, 2 });
        }

        [TestMethod()]
        public void MaximumValueTest()
        {
            int actual = Program.MaximumValue(2, 5, 3, 8, 1, 21, 34, 6, 0);
            Assert.AreEqual(34, actual);
        }

        [TestMethod()]
        public void CommonIntegerElementsTest()
        {
            int[] nums1 = new int[8] { 1, 54, 125, 23, 644, 31, 5, 61 };
            int[] nums2 = new int[10] { 125, 23, 2, 3, 1001, 22, 5, 234, 31, 94 };
            int[] actual = Program.CommonIntegerElements(nums1, nums2);

            CollectionAssert.AreEqual(
                actual,
                new int[4] { 5, 23, 31, 125 });
        }

        [TestMethod()]
        public void CommonStringElementsTest()
        {
            string[] str1 = new string[4] { "Hello", "All", "Csharp", "Ap" };
            string[] str2 = new string[7] { "Ap", "Programming", "First", "Language", "Microsoft", "All", "Csharp" };
            string[] actual = Program.CommonStringElements(str1, str2);

            CollectionAssert.AreEqual(
                actual,
                new string[3] { "All", "Ap", "Csharp" });
        }

        [TestMethod()]
        public void CommonElementsTest()
        {
            string[] str1 = new string[4] { "Hello", "All", "Csharp", "Ap" };
            string[] str2 = new string[7] { "Ap", "Programming", "First", "Language", "Microsoft", "All", "Csharp" };
            string[] actual = Program.CommonElements(str1, str2);
            CollectionAssert.AreEqual(
                actual,
                new string[3] { "All", "Csharp", "Ap" });

            int[] nums1 = new int[8] { 1, 54, 125, 23, 644, 31, 5, 61 };
            int[] nums2 = new int[10] { 125, 23, 2, 3, 1001, 22, 5, 234, 31, 94 };
            int[] actual2 = Program.CommonElements(nums1, nums2);
            CollectionAssert.AreEqual(
                actual2,
                new int[4] { 125, 23, 31, 5 });
        }
    }
}
