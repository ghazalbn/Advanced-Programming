namespace MyProj.Shared.Data
{
    public class Booklet
    {
        public long Id { get; set; }
        public string College { get; set; }
        public string Lesson { get; set; }
        public string Professor { get; set; }
        public string Link { get; set; }
        public Booklet(long id, string college, string lesson, string professor, string link)
        {
            Id = id;
            College = college;
            Lesson = lesson;
            Professor = professor;
            Link = link;
        }
        public Booklet(string lesson, string professor)
        =>(Lesson, Professor) = (lesson, professor);
        public Booklet(){}
    }
}