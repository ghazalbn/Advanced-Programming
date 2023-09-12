namespace Exam2
{
    public class Junior : Programmer
    {
        public Junior(string name, bool isFemale) : base(name, isFemale)
        {}
        public override int Salary{get => 2800000;}
    }
}
