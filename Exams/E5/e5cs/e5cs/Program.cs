using System;

namespace e5cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(rows:2,cols:2);
            m1[0] = new int[2] {1, 2};
            m1[1] = new int[2] {0, 1};

            Matrix m2 = new Matrix(2,2);
            m2[0,0] = 1; m2[0, 1] = -1;
            m2[1,0] = 0; m2[1, 1] = 3;

            Matrix mSum = m1 + m2; 
            // [2, 1]
            // [0, 4]

            Matrix mMul = m1 * m2;
            // [1   5]
            // [0   3]

            Matrix m3 = new Matrix(3, 2);
            Matrix mMul2 = m1 * m2; // DimensionMisMatchException
            Matrix mSu7m2 = m1 + m2; // DimensionMisMatchException

            int m1_1_1 = m1[1,1];
        }
    }
}
