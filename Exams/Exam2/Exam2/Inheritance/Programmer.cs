namespace Exam2
{
    public abstract class Programmer
    {
        public bool IsFemale{get; set;}
        protected string _Name;

        protected Programmer(string name, bool isFemale)
        => (IsFemale, Name) = (isFemale, name);
        public virtual string Name
        {
            get => _Name; 
            set => _Name = (IsFemale?
            $"خانم {value}": $"آقای {value}");
        }
        public abstract int Salary{get;}
    }
}
