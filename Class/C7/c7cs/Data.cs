namespace c7cs
{
    public class Data
    {
        public string Country{get; private set;}
        public int Year{get; private set;}

        public Data(string country, int year)
        {
            this.Country = country;
            this.Year = year;
        }
        public override bool Equals(object obj)
        {
            if(obj is Data)
                return this.Country == (obj as Data).Country && this.Year == (obj as Data).Year;
            return false; 
        }
        public override int GetHashCode()
        {
            return this.Country.GetHashCode() ^ this.Year.GetHashCode();
        }
        public override string ToString() => $"{this.Country} : {this.Year}";
    }
}