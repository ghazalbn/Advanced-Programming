using System;
using System.Collections.Generic;
using System.Drawing;

namespace Exam1_cs.Tests
{
    public class TruckDriver: IPerson, IDriver, ILocatable
    {
        public Color Color { get; set; }
        public List<Traffic> History { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public TruckDriver(string name, long x, long y, long z, Color color)
        => (Firstname, Lastname, X, Y, Z, Color, History) = (name.Split()[0], name.Split()[1], x, y, z, color, new List<Traffic>());
        public long Distance(ILocatable i)
        => (long)Math.Sqrt(Math.Pow(this.X - i.X, 2) + Math.Pow(this.Y - i.Y, 2) + Math.Pow(this.Z - i.Z, 2));

        public void GoToTarget(Customer c, ILocatable i)
        {
            long price = c.Distance(i)*7200;
            if(c.AccountBalance < price)
                throw new StackOverflowException();
            c.AccountBalance -= price;
            (X,Y, Z) = (i.X, i.Y, i.Z);
            (c.X ,c.Y, c.Z) = (i.X, i.Y, i.Z);
        }
        public string VehicleColor() => $"{this.Firstname} {this.Lastname} has a {this.Color.Name.ToLower()} truck!";

        public int CompareTo(object other)
        {
            TruckDriver m = other as TruckDriver;
            return this.Firstname.CompareTo(m.Firstname);
        }
    }
}