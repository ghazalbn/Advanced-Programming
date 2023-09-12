using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A10_cs
{
    public class Management
    {
        public List<Book> allBooks;
        public List<Reader> allMembers;
        public Management()
            => (allBooks, allMembers) = (new List<Book>(), new List<Reader>()); 
		public void Reload(DateTime now)
        {
            Task[] tasks = allMembers
            .Where(m => new TimeSpan(now.Ticks - m.enterTime.Ticks).Days> 365)
            .Select(m => new Task(() => m.notifables
            .ForEach(d => d.Notif("Your Account Closed.")))).ToArray();
            tasks.ToList().ForEach(t => t.Start());
            Task.WaitAll(tasks);
        }

        public void add_book(Book b)
            => allBooks.Add(b);
        public void add_member(Reader r)
            => allMembers.Add(r);
    }
}
