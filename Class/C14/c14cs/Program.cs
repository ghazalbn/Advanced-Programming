using System;
using System.Diagnostics;

namespace c14cs
{
    class Program
    {
        static int Test1(int a, int b)
        {
            System.Threading.Thread.Sleep(100);
            return 10;
        }
        static void Test()
        {
            double d = int.MaxValue;
            for(int i=0; i<int.MaxValue; i++)
                d *= d-i;
            
            Console.WriteLine(d);
        }
        static bool Test2(int[] a, int n)
        {
            System.Threading.Thread.Sleep(300);
            if(a.Length > n) return true;
            return false;
        }

        static bool Work()
        {
            Random rnd = new Random();
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                if(rnd.NextDouble() < 0.5) count++;
            }
            return count <= 50;
        }

        static void Main(string[] args)
        {
            // #1
            TimerN("TestLabel", fn:Test, iter:10);
            TimerN("Test1Label", () => {Test1(1,2);}, iter:30);
            TimerN("Test2Label", () => {Test2(new int[]{1,2,3}, 2);}, iter:30);
            System.Console.WriteLine("-------------------------------------");



            // #2
            TryMethod(Work, 
                () => Console.WriteLine("Success"), 
                () => Console.WriteLine("Failed"));  


            // element.Change(xx).then(
            //     // if success,
            //     // if failed
            // );
        }

        private static void TryMethod(Func<bool> work, Action p1, Action p2)
        {
            System.Console.Write("result: ");
            if(work()) p1();
            else p2();
        }

        private static void TimerN(string v, Action fn, int iter)
        {
            fn();
            Stopwatch s = Stopwatch.StartNew();
            for (int i = 0; i < iter; i++) fn();

            s.Stop();
            Console.WriteLine($"Elapsed time for {v}: {s.Elapsed/iter}");            
        }
    }
}
