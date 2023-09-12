using System;
class Student
{
    double[] Grades;
    int[] Weights;
    public Student(double[] G,int[] W)
    {
        Grades = new double[G.Length];
        Weights = new int[W.Length];
        for (int i = 0; i < W.Length; i++)
        {
            Grades[i] = G[i];
            Weights[i] = W[i];
        }
    }

    public double GetAvg()
    {
        double sum = 0;
        int w = 0;
        for (int i = 0; i < Grades.Length; i++)
        {
            sum+=Grades[i]*Weights[i];
            w+=Weights[i];
        }
        return sum/w;
    }
}