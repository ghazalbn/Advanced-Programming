namespace A10_cs
{
    public class Person
    {
        private string _name;
        public Gender gender;
        public string name
        {
            get => _name; 
            set => _name = (gender == Gender.Male?
            $"Mr.{value}": $"Ms.{value}");
        }
        public Person(string n, Gender g)
            => (gender, name) = (g, n);
        public virtual string Print() => name;
    }
}
