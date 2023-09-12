using System.Collections.Generic;
using System;
using System.Collections;

namespace Exam1_cs
{
    public class Customer : ILocatable, IPerson, IEnumerable
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Traffic> History = new List<Traffic>();
        public long? AccountBalance{get; set;}
        public Customer(string name, long x, long y, long z, long? accountBalance = 0)
        => (Firstname, Lastname, X, Y, Z, AccountBalance) = (name.Split()[0], name.Split()[1], x, y, z, accountBalance);
        public long Distance(ILocatable i)
        => (long)Math.Sqrt(Math.Pow(this.X - i.X, 2) + Math.Pow(this.Y - i.Y, 2) + Math.Pow(this.Z - i.Z, 2));

        public IEnumerator GetEnumerator()
        {
            foreach(Traffic t in History)
                yield return $"{t.source.Name}:{t.target.Name}";
        }

        public static Customer operator +(Customer lhs, long rhs)
        => new Customer($"{lhs.Firstname} {lhs.Lastname}", lhs.X, lhs.Y, lhs.Z, lhs.AccountBalance + rhs);
    }
}