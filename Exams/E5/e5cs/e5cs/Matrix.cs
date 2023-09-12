using System;

namespace e5cs
{
    public class Matrix
    {
        public int[,] Data;

        public int ColCount {set; get ;}
        public int RowCount {set; get ;}

        public Matrix(int rows, int cols)
        {
            this.ColCount = cols;
            this.RowCount = rows;
            this.Data = new int[rows,cols];
        }

        public Matrix(Matrix other)
        {
            this.ColCount = other.ColCount;
            this.RowCount = other.RowCount;
            this.Data = other.Data;
        }        
        public class DimensionMisMatchException: Exception 
        {
        }

        public int[] this[int i]
        {
            get
            {
                int[] a = new int[this.RowCount];
                for (int j = 0; j < RowCount; j++)
                    a[j] = this.Data[i,j];
                return a;
            }
            set
            {
                for (int j = 0; j < RowCount; j++)
                    this.Data[i,j] = value[j];
            }
        }

        public int this[int i, int j]
        {
            get{ return this.Data[i,j];}
            set{this.Data[i,j] = value;}
        }

        // throw exception DimensionMisMatchException if dimensions don't match
        // You have to define DimensionMisMatchException yourself
        public static Matrix operator+(Matrix lhs, Matrix rhs)
        {
            if(lhs.ColCount != rhs.ColCount || lhs.RowCount != rhs.RowCount)
                throw new DimensionMisMatchException();
            Matrix sum = new Matrix(lhs);
            for (int i = 0; i < lhs.ColCount; i++)
            {
               for (int j = 0; j < lhs.RowCount; j++)
                sum[i,j] += rhs[i,j];
            } 
            return sum;
        }

        // Extra Point
        // throw exception DimensionMisMatchException if dimensions don't match
        public static Matrix operator*(Matrix lhs, Matrix rhs)
        {
            if(lhs.ColCount != rhs.RowCount)
                throw new DimensionMisMatchException();
            Matrix mul = new Matrix(lhs.RowCount, rhs.ColCount);
            for (int i = 0; i < mul.ColCount; i++)
            {
                for (int j = 0; j < mul.RowCount; j++)
                {
                    mul[i,j] = 0;
                    for (int s = 0; s <rhs.ColCount ; s++)
                        mul[i,j] += rhs[i,s]*lhs[s,j];
                }
                
            }
            return mul;
        }
    }
}