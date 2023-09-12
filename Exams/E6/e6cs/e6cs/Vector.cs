using System;
using System.Diagnostics.CodeAnalysis;

namespace e6cs.Tests
{
    public class Vector: IVector, IComparable<Vector>, IEquatable<Vector>
    {
        private int[] Nums;
        public double Magnitude 
        {
            get
            {
                double s = 0;
                foreach(int n in this.Nums)
                    s += n*n; 
                return Math.Sqrt(s);
            }
            set
            {
                foreach(int n in this.Nums)
                    this.Magnitude += n*n;  
            } 
        }
        public Vector(params int[] nums)
        {
            this.Nums = nums;
        }
        public int Length{get{return this.Nums.Length;}}

        public int this[int i]
        {
            get
            {
                return this.Nums[i];
            }
            set
            {
                this.Nums[i] = value;
            }
        }

        public int CompareTo(Vector other)
        {
            if(this.Length == other.Length)
                {
                    if(this.Magnitude == other.Magnitude)
                        return 0;
                    else if(this.Magnitude > other.Magnitude)
                        return 1;
                    else if(this.Magnitude < other.Magnitude)
                        return -1;
                }
            return -2;
        }

        public bool Equals([AllowNull] Vector other)
        {
            for(int i = 0; i < other.Length; i++)
            {
                if(this[i] != other[i])
                    return false;
            }
            return this.Length == other.Length;
        }
    }
}