using System.Collections.Generic;
using System.Drawing;
using System;

namespace Exam1_cs
{
    public class CarDriver : IDriver, IPerson, ILocatable
    {

        public Color Color { get; set; }
        public List<Traffic> History { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public CarDriver(string name, long x, long y, long z, Color color)
        => (Firstname, Lastname, X, Y, Z, Color, History) = (name.Split()[0], name.Split()[1], x, y, z, color, new List<Traffic>());
        public long Distance(ILocatable i)
        => (long)Math.Sqrt(Math.Pow(this.X - i.X, 2) + Math.Pow(this.Y - i.Y, 2) + Math.Pow(this.Z - i.Z, 2));

        public void GoToTarget(Customer c, ILocatable i)
        {
            long price = c.Distance(i)*3000;
            if(c.AccountBalance < price)
                throw new StackOverflowException();
            c.AccountBalance -= price;
            (X,Y, Z) = (i.X, i.Y, i.Z);
            (c.X ,c.Y, c.Z) = (i.X, i.Y, i.Z);
        }
        public string VehicleColor() => $"{this.Firstname} {this.Lastname} has a {this.Color.Name.ToLower()} car!";

        public int CompareTo(object other)
        {
            long h1 = 0, h2 = 0;
            CarDriver m = other as CarDriver;
            foreach(Traffic t in this.History)
                h1 += t.source.Distance(t.target);
            foreach(Traffic t in m.History)
                h2 += t.source.Distance(t.target);
            if(h1 > h2)
                return 1;
            if(h1<h2)
                return -1;
            return 0;
        }

        public static CarDriver operator +(CarDriver lhs, Traffic rhs)
        {
            lhs.History.Add(rhs);
            return lhs;
        }
    }
}