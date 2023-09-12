namespace MyProj.Shared.Data
{
    public class Comment
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public string Text { get; set; }
        public Comment(long id, string text)
        => (TeacherId, Text) = (id, text);
        public Comment(){}
    }
}