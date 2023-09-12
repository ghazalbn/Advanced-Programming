namespace MyProject.Models
{
    public class Teacher
    {
        public long Id { get; set; }
        public string College { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int BehaviorRate { get; set; } = 0;
        public int TeachingRate { get; set; } = 0;
        public int ScoreRate { get; set; } = 0;
        public int ExamRate { get; set; } = 0;
        public int AttendanceRate { get; set; } = 0;
        public long VoteNum { get; set; } = 0;
        public Teacher(){}
        public int TotalRate
        => (BehaviorRate + TeachingRate + ScoreRate + ExamRate + AttendanceRate)/5;
        public string BehaviorStage
        {
            get => BehaviorRate<25? "ضعیف": BehaviorRate<50? "متوسط":BehaviorRate<75? "خوب": "عالی";
        }
        public string TeachingStage
        {
            get => TeachingRate<25? "ضعیف": TeachingRate<50? "متوسط":TeachingRate<75? "خوب": "عالی";
        }
        public string ScoreStage
        {
            get => ScoreRate<34? "کمتر از نمره دانشجو": ScoreRate<67? "همان نمره دانشجو": "بالاتر از نمره دانشجو";
        }
        public string ExamStage
        {
            get => ExamRate<34? "سخت": ExamRate<67? "متوسط":"آسان";
        }
        public string AttendanceStage
        {
            get => ExamRate<34? "هرجلسه": ExamRate<67? "اغلب":"به ندرت";
        }
    }
}