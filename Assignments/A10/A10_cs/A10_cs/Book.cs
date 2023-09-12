namespace A10_cs
{
    public class Book
    {
        //TODO
        public long book_id;
        public string author;
        public string name;
        public Status status;

        public Book(long bi, string a, string n, Status s)
            => (book_id, author, name, status) = (bi, a, n, s);
    }
}