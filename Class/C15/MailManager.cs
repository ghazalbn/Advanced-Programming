using System;

namespace C15
{
    class MailInfo
    {
        public readonly string From;
        public readonly string To;
        public readonly string Title;
        public MailInfo(string from, string to, string title) => 
            (From, To, Title) = (from, to, title);
    }

    internal class MailManager
    {
        public event Action<MailInfo> NewMail;

        public void OnNewMail(MailInfo mi)
        {
            NewMail(mi);
        }

        internal void SimulateNewMail(string v1, string v2, string v3)
        {
            MailInfo mi = new MailInfo(v1, v2, v3);
            OnNewMail(mi);
        }
    }
}