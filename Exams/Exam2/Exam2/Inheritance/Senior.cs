using System;
namespace Exam2
{
    public class Senior: Programmer
    {
        public Senior(string name, bool isFemale) : base(name, isFemale)
        {}
        protected virtual int Rate{get => 50000;}
        public override int Salary{get => 4500000;}
        public virtual int CalculateSalary(int extraWork)
        => this.Salary + extraWork*Rate;
    }
}
