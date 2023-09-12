using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Exam2
{
    public class Matrix
    {
        public int M;
        public int N;
        public int[,] Numbers;

        public Matrix(int m, int n, int[,] values)
        => (M, N, Numbers) = (m, n, values);
        public int this[int i, int j]
        {
            get{ return this.Numbers[i,j];}
            set{this.Numbers[i,j] = value;}
        }
        public static explicit operator Matrix(int[,] values) 
        => new Matrix(values.Length, values.GetLength(0), values);
        public static explicit operator int[,](Matrix m) 
        {
            int[,] values = new int[m.M, m.N];
            for (int i = 0; i < m.M; i++)
            {
                for(int j = 0; j < m.N; j++)
                    values[i,j] = 2*m.Numbers[i,j];
            }
            return values;
        }
        public async Task<Matrix> AddMatrix(Matrix matrix)
        {
            Matrix m = new Matrix(M, N, Numbers);
            Task[] tasks = new Task[M*N];
            for (int i = 0; i < M; i++)
            {
               for (int j = 0; j < N; j++)
                    tasks[i] = Task.Run(() => m[i,j] += matrix[i,j]);
            }
            await Task.WhenAll(tasks);
            return m;
        }

        public Matrix MultiplyMatrix(Matrix matrix)
        {
            return null;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < M; i++)
            {
                for(int j = 0; j < N; j++)
                    s += $"{Numbers[i, j]} ";
            }
            return s.TrimEnd();
        }

    }
}
