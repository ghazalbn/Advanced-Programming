using System;
using System.Threading;

namespace A8_cs
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReminderThread;
        public int Delay{get;}

        public string Msg{get;}

        public event Action<string> Reminder;

        public SingleReminderThread(string msg, int delay)
            => (Msg, Delay) = (msg, delay);


        public void Start()
        {
            ReminderThread = new Thread((msg) => 
            {Thread.Sleep(Delay);  
            Reminder((string)msg);
            });
            ReminderThread.Start(Msg);
        }
    }
}