using System;

namespace e0
{
    public class Program
    {
        public static int solve(String s)
        {
            int d = 0;
            while (s.IndexOf("RL")>=0)
            {
             s = s.Replace("RL","LR");
             d++;   
            }
            return d;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
