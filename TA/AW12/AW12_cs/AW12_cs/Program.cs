using System;
using System.IO;

namespace AW12_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter f1 = new Fighter("Mehdi", 30);
            Fighter f2 = new Fighter("mohi", 40);
            System.Console.WriteLine($"{f1.Name} ... {f2.Name}");
            while(true)
            {
                f1.Attack(f2);
                f2.Attack(f1);
                System.Console.WriteLine($"{f1.Health} ....... {f2.Health}");
            }
        }
    }
}
