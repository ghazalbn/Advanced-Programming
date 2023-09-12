using System;

namespace C15
{
    internal class Pager
    {
        private MailManager mm;

        public Pager(MailManager mm)
        {
            this.mm = mm;
            mm.NewMail += (mail) => Page($"New mail from: {mail.From}");
        }

        private void Page(string msg)
            => Console.WriteLine($"Paging: {msg}");            

    }
}