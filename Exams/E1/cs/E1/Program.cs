using System;

namespace E1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] Grades = new double[5]{15,18.5,19.25,16,17};
            int[] Weights = new int[5]{3,2,1,3,3};
            Student s = new Student(Grades,Weights);
            Console.WriteLine(s.GetAvg());
        }
    }
}
