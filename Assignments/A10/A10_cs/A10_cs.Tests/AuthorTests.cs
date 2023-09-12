using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace A10_cs.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void AuthorConstructor_Test()
        {
            typeof(Person).IsAssignableFrom(typeof(Author));

            Assert.IsTrue(typeof(Author).GetFields()
                                        .Select(field => field.Name)
                                        .ToList()
                                        .Contains("books"));

            Author a = new Author("Jeffery Richter", Gender.Male);
            Assert.AreEqual(a.books.Count, 0);

            Book b = new Book(12, "Jeffery Richter", "ClR Via C#", Status.Reserved);
            a.new_book(b);
            Assert.AreEqual(a.books.Count, 1);
            Assert.AreEqual("Mr." + b.author, a.name);

        }

        [TestMethod]
        public void AuthorPrint_Test()
        {
            Author a = new Author("Jeffery Richter", Gender.Male);
            Assert.AreEqual(a.books.Count, 0);

            Book b1 = new Book(12, "Jeffery Richter", "ClR Via C#", Status.Reserved);
            Book b2 = new Book(12, "Jeffery Richter", "Windows Via C", Status.Free);

            a.new_book(b1);
            a.new_book(b2);
            Assert.AreEqual(a.Print(), "Mr.Jeffery Richter with 2 books.");

            Person p = a;
            Assert.AreEqual(p.Print(), "Mr.Jeffery Richter with 2 books.");
        }
    }
}
