using System;
using System.Threading;
using System.Threading.Tasks;

namespace A8_cs
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReiminderTask = null;
        public int Delay{get;}

        public string Msg{get;}

        public event Action<string> Reminder;

        public SingleReminderTask(string msg, int delay)
            => (Msg, Delay) = (msg, delay);


        public void Start()
        {
            ReiminderTask = new Task(() => 
            {Thread.Sleep(Delay);  
            Reminder(Msg);});
            ReiminderTask.Start();
            ReiminderTask.Wait();
        }
    }
}