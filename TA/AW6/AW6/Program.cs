using System;

namespace AW6
{
    public enum Athlete
        {
            Height = 1,
            LongHands = 2,
            LongLegs = 4,
            Pace = 8,
            Brain = 16,
            None = 32
        }
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static string WhichSport(Athlete a)
        {
            if((Athlete.Height & a) == Athlete.Height && (Athlete.LongHands & a) == Athlete.LongHands && (Athlete.Pace & a) == Athlete.Pace)
                return "Volleyball";
            if ((Athlete.Height & a) == Athlete.Height && (Athlete.LongHands & a) == Athlete.LongHands) 
                return "Basketball";
            if((Athlete.LongLegs & a) == Athlete.LongLegs)
                return "Karate";
            if((Athlete.Brain & a) == Athlete.Brain && (Athlete.Pace & a) == Athlete.Pace)
                return "Boxing";
            if((Athlete.Brain & a) == Athlete.Brain)
                return "Chess";
            
            return "Mench!!!";
        }
    }
}
