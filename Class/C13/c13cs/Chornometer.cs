using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace c13cs
{
    internal class Chornometer: IStopwatch, IDisposable, IEnumerable<string>
    {
        private Stopwatch s = new Stopwatch();
        private string Name;
        List<string> Marks = new List<string>();

        public Chornometer(string name)
        {
            this.Name = name;
        }

        public void Dispose()
        {
            this.Stop();
            Console.WriteLine($"Elapsed Time({this.Name}): {s.Elapsed.ToString()}"); 
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach(string m in Marks)
                yield return m;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach(string m in Marks)
                yield return m;
        }
        public void Mark(string name)
        {
            this.Marks.Add(name);
        }

        public void Start()
        {
            s.Start();
        }

        public void Stop()
        {
            s.Stop();
        }

    }
}