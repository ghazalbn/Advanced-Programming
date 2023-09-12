using System;

namespace c19cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(name:"Ball", color: ConsoleColor.Red, center: new Point(1.5, 2.4), radius:7.5);
            c.Draw();
            Console.WriteLine("-----------------------------");
            c.PrintInfo();
            Console.WriteLine("-----------------------------");

            var Rpoints = new Point[]
            {new Point(3,5), new Point(1,2.2), new Point(1, 3.2), new Point(4, 5)};
            var Tpoints = new Point[]
            {new Point(3,5), new Point(1,2.2), new Point(1, 3.2)};

            Shape r = new Rectangle("Box", ConsoleColor.Blue, Rpoints);
            r.Draw();
            Console.WriteLine("-----------------------------");
            r.PrintInfo();
            Console.WriteLine("-----------------------------");

            Shape t = new Triangle("Funnel", ConsoleColor.Yellow, Tpoints);
            t.Draw();
            Console.WriteLine("-----------------------------");
            t.PrintInfo();
            Console.WriteLine("-----------------------------");

            var Spoints = new Point[]
            {new Point(3,5), new Point(3,6), new Point(4, 6), new Point(5,5)};
            Shape s = new Square("Chest", ConsoleColor.Cyan, Spoints);
            s.Draw();
            Console.WriteLine("-----------------------------");
            s.PrintInfo();
            Console.WriteLine("-----------------------------");

            Console.ReadKey();
        }
    }
}
