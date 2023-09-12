using System;
using System.Diagnostics;

namespace l19cs
{
    internal class Timer: IDisposable
    {
        private Stopwatch s = new Stopwatch();
        private string Name;
        public Timer(string name)
        {
            this.Name = name;
            s.Start();
        }

        public void Dispose()
        {
            s.Stop();
            Console.WriteLine($"Elapsed Time({this.Name}): {s.Elapsed.ToString()}");            
        }
    }
}