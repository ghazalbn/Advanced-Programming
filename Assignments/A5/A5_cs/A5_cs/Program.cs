using System;
using System.IO;

namespace A5
{
    class Program
    {
            static void Main(string[] args)
        {
            mAC((-int.MaxValue).ToString());
            Console.ReadKey();
        }
        public static void mAC(string v)
        {
            int a = int.Parse(v)-10;
        }
    }
}
