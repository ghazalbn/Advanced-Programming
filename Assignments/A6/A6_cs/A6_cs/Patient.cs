namespace A6
{
    public class Patient : IPerson
    {
        public string Firstname { get;}
        public string Lastname { get;}
        public string Disease;
        public bool Recovered;

        public Patient(string firstname, string lastname, string disease, bool recovered)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Disease = disease;
            this.Recovered = recovered;
        }

        
    }
}
