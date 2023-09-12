using System.IO;
using System;
using System.Linq;

namespace c18cs
{
    class Program
    {
        static void Main(string[] args)
        {
            var pop = File.ReadAllLines( "population.csv");
            var s = File.ReadAllLines( "suicide-rates-by-country.csv");
            var sResult = s.Skip(1).Select(l => (country: l.Split(',')[0],
                            year: l.Split(',')[2],
                            rate: l.Split(',')[3]));
            var popResult = pop.Skip(1).Select(l => (country: l.Split(',')[0],
                            year: l.Split(',')[2],
                            pop: l.Split(',')[3]));

            Console.WriteLine("The country had most suicide:\n");
            Console.WriteLine(sResult.Join(popResult, t => (c: t.country, y: t.year),
            t => (c: t.country, y: t.year),(t1, t2) => (t1.country, t1.year,
            suicide: double.Parse(t1.rate)*double.Parse(t2.pop)))
            .OrderByDescending(l => l.suicide).First() + "\n");

            System.Console.WriteLine("----------------------------------\n");

            System.Console.WriteLine("Most suicide of each country:\n");
            sResult.GroupBy(l => l.country).ToList()
            .ForEach(l => Console.WriteLine(l.Aggregate((l1,l2) => 
            double.Parse(l1.rate)>double.Parse(l2.rate)?l1:l2)));
        }
    }
}
