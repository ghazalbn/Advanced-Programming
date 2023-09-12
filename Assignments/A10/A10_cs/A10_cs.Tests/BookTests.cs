using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace A10_cs.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void BookConstructor_Test()
        {
            List<string> listOfFields = new List<string>()
            {
                "status",
                "book_id",
                "name",
                "title",
                "author"
            };
            typeof(Book).GetFields()
                        .Select(field => field.Name)
                        .ToList()
                        .ForEach(d => Assert.IsTrue(listOfFields.Contains(d)));
            Book b = new Book(12, "Jeffery Richter", "ClR Via C#", Status.Reserved);
        }
    }
}
