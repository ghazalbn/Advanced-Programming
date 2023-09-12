using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A10_cs.Tests
{
    [TestClass]
    public class ManagementTests
    {
        [TestMethod]
        public void ManagementConstructor_Test()
        {
            Management m = new Management();

            Book b1 = new Book(12, "Jeffery Richter", "ClR Via C#", Status.Reserved);
            Book b2 = new Book(34, "Victor Hugo", "The Man Who Laughs", Status.Free);
            Book b3 = new Book(56, "William Shakespeare", "Four Tragedies", Status.Free);
            Book b4 = new Book(78, "Mehdi Akhavan Sales", "Arghanoon", Status.Free);

            Reader r1 = new Reader("Marzieh Mohammadi", Gender.Female, new DateTime(2019, 5, 23));
            Reader r2 = new Reader("Elnaz Abbasi", Gender.Female, new DateTime(2019, 7, 3));
            Reader r3 = new Reader("Amir Ferdowsi", Gender.Male, new DateTime(2015, 4, 13));
            Reader r4 = new Reader("Atoosa Amiri", Gender.Female, new DateTime(2019, 5, 15));

            m.add_book(b1);
            m.add_book(b2);
            m.add_book(b3);
            m.add_book(b4);

            m.add_member(r1);
            m.add_member(r2);
            m.add_member(r3);
            m.add_member(r4);

            Assert.AreEqual(m.allBooks.Count, 4);
            Assert.AreEqual(m.allMembers.Count, 4);
        }
        [TestMethod]
        public void ManagementReload_Test()
        {
            Management m = new Management();

            Book b1 = new Book(12, "Jeffery Richter", "ClR Via C#", Status.Free);
            Book b2 = new Book(34, "Victor Hugo", "The Man Who Laughs", Status.Free);
            Book b3 = new Book(56, "William Shakespeare", "Four Tragedies", Status.Free);
            Book b4 = new Book(78, "Mehdi Akhavan Sales", "Arghanoon", Status.Free);

            Reader r1 = new Reader("Marzieh Mohammadi", Gender.Female, new DateTime(2019, 5, 23));
            Reader r2 = new Reader("Elnaz Abbasi", Gender.Female, new DateTime(2019, 7, 3));
            Reader r3 = new Reader("Amir Ferdowsi", Gender.Male, new DateTime(2019, 4, 13));
            Reader r4 = new Reader("Atoosa Amiri", Gender.Female, new DateTime(2019, 5, 15));

            m.allBooks = new List<Book>() { b1, b2, b3, b4 };
            m.allMembers = new List<Reader>() { r1, r2, r3, r4 };
            m.allMembers.ForEach(d =>
            {
                d.notifables.Add(new Email());
                d.notifables.Add(new Mobile());
            }
            );
            m.Reload(new DateTime(2020, 5, 22));

            Assert.AreEqual(m.allMembers[2].notifables[0].Messages[0], "Sent email : Your Account Closed.");
            Assert.AreEqual(m.allMembers[2].notifables[1].Messages[0], "Sent short message : Your Account Closed.");

            Assert.AreEqual(m.allMembers[3].notifables[0].Messages[0], "Sent email : Your Account Closed.");
            Assert.AreEqual(m.allMembers[3].notifables[1].Messages[0], "Sent short message : Your Account Closed.");
        }
    }
}
