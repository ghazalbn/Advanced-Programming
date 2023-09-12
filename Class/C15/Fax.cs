using System;

namespace C15
{
    internal class Fax
    {
        private MailManager mm;
        Action<MailInfo> sendFax;

        public Fax(MailManager mm)
        { 
            this.mm = mm;
            sendFax = (mail) => SendFax($"From: {mail.From}, To: {mail.To}\nTitle: {mail.Title}");
            Register(mm);
        }
        private void SendFax(string msg)
            => Console.WriteLine($"Fax Sent: {msg}");            

        public void Register(MailManager mm)
            => mm.NewMail += sendFax;  
        public void UnRegister()
            => mm.NewMail -= sendFax;

    }
}