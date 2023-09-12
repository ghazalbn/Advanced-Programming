using System;
using static System.Console;
namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c0 = new Circle(2,2,2);
            Circle c1 = new Circle(4,3,3);
            WriteLine(c0.Area());
            WriteLine(c0.Circumference());
            WriteLine(c0.DistanceFromCenter(c1));
        }
    }
}
