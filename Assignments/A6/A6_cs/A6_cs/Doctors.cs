using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace A6
{
    public class Doctors<T>
    {
        public List<T> Doctor;

        public Doctors()
        {
            Doctor = new List<T>();
        }

        public List<string> ListOfRecoveredPatients()
        {
            List<string> Recovered = new List<string>();
            foreach(IDoctor d in Doctor)
            {
                foreach(Patient p in d.patients)
                {
                    if(p.Recovered)
                        Recovered.Add($"{p.Firstname} {p.Lastname}");
                }
            }
            return Recovered;
        }
        public List<string> SortDoctors()
        {
            Doctor.Sort();
            List<string> names = new List<string>();
            foreach(IPerson d in Doctor)
                names.Add($"{d.Firstname} {d.Lastname}");
            return names;
        }

        public void AddDoctor(T d)
        {
            Doctor.Add(d);
        }
    }
}
