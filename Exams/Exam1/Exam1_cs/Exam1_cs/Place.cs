using System;
namespace Exam1_cs
{
    public class Place : ILocatable
    {
        public string Name;
        public long X{get; set;}
        public long Y{get; set;}
        public long Z{get;set;}

        public Place(string Name, long X, long Y, long Z)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public long Distance(ILocatable i)
        => (long)Math.Sqrt(Math.Pow(this.X - i.X, 2) + Math.Pow(this.Y - i.Y, 2) + Math.Pow(this.Z - i.Z, 2));
    }
}