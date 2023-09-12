namespace Exam2
{
    public class FullStack: Senior
    {
        public FullStack(string name, bool isFemale) : base(name, isFemale)
        {}
        protected override int Rate{get => 70000;}
        public override int Salary{get => 7500000;}
        public override string Name
        {
            get => _Name; 
            set => _Name = $"دکتر {value}";
        }
    }
}
