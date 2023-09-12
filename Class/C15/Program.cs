using System;

namespace C15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Construct a MailManager object
            MailManager mm = new MailManager();

            // Construct a Pager object passing it the MailManager object
            Pager pager = new Pager(mm);
            
            // Construct a Fax object passing it the MailManager object
            Fax fax = new Fax(mm);

            // Simulate an incoming mail message
            mm.SimulateNewMail("Jeffrey", "Kristin", "I Love You!");

            // Force the Fax object to unregister itself with the MailManager
            fax.UnRegister();

            // Simulate an incoming mail message
            mm.SimulateNewMail("Jeffrey", "Mom & Dad", "Happy Birthday.");        }
    }
}
