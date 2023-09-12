using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A10_cs
{
    public class Reader : Person
    {
        public DateTime enterTime;
        public List<Tuple<Book,DateTime>> borrowed_Books;
        public List<Notifable> notifables;
        public Reader(string name, Gender gender, DateTime enterTime)
        : base(name, gender)
            => (this.enterTime, borrowed_Books, notifables) =
            (enterTime, new List<Tuple<Book, DateTime>>(), new List<Notifable>());

        public override string Print()
            => $"{base.Print()} , {enterTime.Year}/{enterTime.Month}/{enterTime.Day}";

        public void borrow_book(Book b,DateTime now)
        {
            if(b.status == Status.Free && borrowed_Books.Count < 2)
                borrowed_Books.Add((b, now).ToTuple());
        }
        
        public Task<long> return_book(long book_id,DateTime now)
        {
            var book = borrowed_Books.Find(t => t.Item1.book_id == book_id);
            var dfs = new TimeSpan(now.Ticks - book.Item2.Ticks).Days -14;
            return new Task<long>(() => 
            {borrowed_Books.Remove(book); return dfs > 0? dfs*1000:0;});
        }

        public IEnumerable<string> show_book()
            => borrowed_Books.Select(t => t.Item1.name);
    }
}
