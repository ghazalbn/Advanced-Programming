namespace MyProj.Shared.Data
{
    public class Professor
    {
        public long Id { get; set; }
        public string College { get; set; }
        public string Name { get; set; }
        public int BehaviorRate { get; set; } = 0;
        public int TeachingRate { get; set; } = 0;
        public int ScoreRate { get; set; } = 0;
        public int AttendanceRate { get; set; } = 0;
        public int ExamRate { get; set; } = 0;
        public long VoteNum { get; set; } = 0;
        public int TotalRate
        => (BehaviorRate + TeachingRate + ScoreRate + ExamRate + AttendanceRate)/5;
        public Professor(string name, string college, long id)
        => (Name, College, Id) = (name, college, id);
    }
}