namespace MyProj.Shared.Data
{
    public class Rate
    {
        public int Behavior { get; set; }
        public int Teaching { get; set; }
        public int Score { get; set; }
        public int Exam { get; set; }
        public int Attendance { get; set; }
        // public Rate(int bR, int tR, int sR, int eR, int aR)
        // => (Behavior, Teaching, Score, Exam, Attendance) = (bR, tR, sR, eR, aR);
        public Rate(){}
    }
}