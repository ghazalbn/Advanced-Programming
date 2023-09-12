using System;
using System.Collections;
using System.Collections.Generic;

namespace A10_cs
{
    public class Author : Person
    {
        public List<Book> books;

        public Author(string n, Gender g) : base(n, g)
        => books = new List<Book>();

        public void new_book(Book b)
          => books.Add(b);
        public override string Print()
          => $"{base.Print()} with {books.Count} books.";
    }
}
