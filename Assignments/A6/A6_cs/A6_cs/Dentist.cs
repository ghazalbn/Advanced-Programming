using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace A6
{
    public class Dentist : IPerson, IDoctor
    {
        public string Firstname{get;}

        public string Lastname{get;}

        public string Field{get;}

        public long Salary{get;}

        public string University{get;}

        public List<Patient> patients{get; set;}
        public Dentist(string firstname, string lastname, string field, long salary, string university)
        {
            (Field, Lastname, Firstname,Salary,University) = (field, lastname, firstname,salary,university);
            this.patients = new List<Patient>();
        }
        public static Dentist operator +(Dentist d ,Patient p)
        {
            if(p.Disease.Contains("Dental") || p.Disease.Contains("Teeth") || p.Disease.Contains("Toothache"))
                d.patients.Add(p);
            return d;
        } 
        public static bool operator >(Dentist lhs, Dentist rhs) => lhs.Salary > rhs.Salary;
        public static bool operator <(Dentist lhs, Dentist rhs) => lhs.Salary < rhs.Salary;
        public string Work() => $"This Dentist works on {this.Field}";
         public string GraduatedFrom()
        {
            string uni = "";
            for(int i = 0; i< University.Length; i++)
            {
                if(int.TryParse(University[i+1].ToString(), out int t))
                    break;
                uni += University[i];
            }
            return $"{this.Firstname} {this.Lastname} is graduated from {uni}";
        }

        public int CompareTo(IDoctor other)
        {
            int d1 = 0;
            int d2 = 0;
            foreach(Patient p in this.patients)
            {
                if(p.Recovered)
                    d1++;
            }
            foreach(Patient p in other.patients)
            {
                if(p.Recovered)
                    d2++;
            }
            if((double)d1/this.patients.Count > d2/(double)other.patients.Count)
                return 1;
            if((double)d1/this.patients.Count < d2/(double)other.patients.Count)
                return -1;
            return this.Firstname.CompareTo((other as IPerson).Firstname);
        }
    }
}
