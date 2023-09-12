using System;

namespace A8_cs
{
    public interface ISingleReminder
    {
        int Delay { get; }
        string Msg { get; }
        event Action<string> Reminder;
        void Start();
    }
}