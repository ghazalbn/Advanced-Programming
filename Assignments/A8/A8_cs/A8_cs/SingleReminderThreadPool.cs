using System;
using System.Threading;

namespace A8_cs
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public int Delay{get;}

        public string Msg{get;}

        public event Action<string> Reminder;

        public SingleReminderThreadPool(string msg, int delay)
            => (Msg, Delay) = (msg, delay);


        public void Start()
            => ThreadPool.QueueUserWorkItem((msg) => 
            {Thread.Sleep(Delay);  
            Reminder((string)msg);
            }, Msg);
    }
}