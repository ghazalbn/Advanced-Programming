using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A10_cs.Tests
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void ReaderConstructor_Test()
        {
            typeof(Person).IsAssignableFrom(typeof(Reader));

            string[] fields = typeof(Reader).GetFields().Select(field => field.Name).ToArray();
            Assert.IsTrue(fields.Contains("enterTime"));
            Assert.IsTrue(fields.Contains("borrowed_Books"));
            Assert.IsTrue(fields.Contains("notifables"));
        }
        [TestMethod]
        public void ReaderPrint_Test()
        {
            Reader reader = new Reader("Joel Matip", Gender.Male, new DateTime(2020, 4, 23));
            Assert.AreEqual(reader.Print(), "Mr.Joel Matip , 2020/4/23");
        }
        [TestMethod]
        public void ReaderBorrowBook_Test()
        {
            Reader reader = new Reader("Afvrin Fawx", Gender.Female, new DateTime(2014, 5, 3));

            Book b1 = new Book(12, "Jeffery Richter", "ClR Via C#", Status.Reserved);
            Book b2 = new Book(34, "Victor Hugo", "The Man Who Laughs", Status.Free);
            Book b3 = new Book(56, "William Shakespeare", "Four Tragedies", Status.Free);
            Book b4 = new Book(78, "Mehdi Akhavan Sales", "Arghanoon", Status.Free);

            reader.borrow_book(b1, new DateTime(2014, 6, 7));
            reader.borrow_book(b2, new DateTime(2014, 5, 8));
            reader.borrow_book(b3, new DateTime(2014, 9, 9));
            reader.borrow_book(b4, new DateTime(2014, 2, 7));

            Assert.AreEqual(reader.borrowed_Books.Count, 2);
            Assert.AreEqual(reader.borrowed_Books[0].Item1.name, "The Man Who Laughs");
            Assert.AreEqual(reader.borrowed_Books[1].Item1.name, "Four Tragedies");
        }
        [TestMethod]
        public void ReaderShowBook_Test()
        {
            Reader reader = new Reader("Afvrin Fawx", Gender.Female, new DateTime(2014, 5, 3));

            Book b1 = new Book(12, "Jeffery Richter", "ClR Via C#", Status.Free);
            Book b2 = new Book(78, "Mehdi Akhavan Sales", "Arghanoon", Status.Free);

            reader.borrow_book(b1, new DateTime(2014, 6, 7));
            reader.borrow_book(b2, new DateTime(2014, 5, 8));

            IEnumerable<string> names = reader.show_book();

            Assert.AreEqual(names.ToArray()[0], "ClR Via C#");
            Assert.AreEqual(names.ToArray()[1], "Arghanoon");

        }
        [TestMethod]
        public void ReaderReturnBook_Test()
        {
            Reader reader = new Reader("Afvrin Fawx", Gender.Female, new DateTime(2014, 5, 3));

            Book b1 = new Book(34, "Victor Hugo", "The Man Who Laughs", Status.Free);
            Book b2 = new Book(56, "William Shakespeare", "Four Tragedies", Status.Free);

            reader.borrow_book(b1, new DateTime(2014, 6, 7));
            reader.borrow_book(b2, new DateTime(2014, 5, 29));

            Task<long> Tax = reader.return_book(34,new DateTime(2014,7,2));
            Assert.AreEqual(reader.borrowed_Books.Count, 2);
            Tax.Start();
            Tax.Wait();
            Assert.AreEqual(reader.borrowed_Books.Count, 1);
            Assert.AreEqual(Tax.Result, 11000);

            Task<long> WithoutTax = reader.return_book(56, new DateTime(2014, 6, 1));
            Assert.AreEqual(reader.borrowed_Books.Count, 1);
            WithoutTax.Start();
            WithoutTax.Wait();
            Assert.AreEqual(reader.borrowed_Books.Count, 0);
            Assert.AreEqual(WithoutTax.Result, 0);
        }
    }
}
