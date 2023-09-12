using System;

namespace c13cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Chornometer c;
            using (c = new Chornometer(name:"Swim time"))
            {
                c.Start();
                c.Mark("Lap1");
                c.Mark("Lap3");
                c.Mark("Final");
            }
            // c.Stop();

            foreach(var mark in c)
            {
                Console.WriteLine($"Your mark: {mark}");                
            }
        }
    }
}
