using System;
using System.Collections.Generic;

namespace A10_cs
{
    public class Notifable
    {
        public List<string> Messages;
        public Notifable() => Messages = new List<string>();
        public virtual string Notif(string msg)
        {
            Messages.Add(msg);
            return msg;
        }
    }
    public class Email : Notifable
    {
        public override string Notif(string msg)
        =>  base.Notif($"Sent email : {msg}");
    }
    public class Mobile: Notifable
    {
        public override string Notif(string msg)
        =>  base.Notif($"Sent short message : {msg}");
    }
}
