using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace A8_cs
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
			Stopwatch s = new Stopwatch();
            s.Start();
            foreach (var act in actions) act();
            s.Stop();
            return s.ElapsedMilliseconds;
        }

        public static long CallParallel(params Action[] actions)
        {
			Stopwatch s = new Stopwatch();
        
            Task[] tasks = new Task[actions.Length];
            s.Start();
            for (int i = 0; i < actions.Length; i++)
            {
                tasks[i] = new Task(actions[i]);
                tasks[i].Start();
            }
            Task.WaitAll(tasks);
            s.Stop();
            return s.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            lock (actions)
            {
                
                foreach(var action in actions)
                {
                    for (int j = 0; j < count; j++)
                    {
                        Task task = new Task(action);
                        task.Start();
                        task.Wait();
                    }
                }
            }
            s.Stop();
            return s.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
            => await Task.Run(() => CallSequential(actions));

        public static async Task<long> CallParallelAsync(params Action[] actions)
            => await Task.Run(() => CallParallel(actions));

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
            => await Task.Run(() => CallParallelThreadSafe(count, actions));
    }
}