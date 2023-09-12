using System;
using System.IO;
using System.Linq;

namespace c17cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines(@"children-per-woman-UN.csv");
            System.Console.WriteLine("Highest Ratio of All:\n");
            file
            .Skip(1)
            .Select(l => {
                var tokens = l.Split(",");
                return(
                    country: tokens[0],
                    year: tokens[2],
                    estimates: tokens[3]

                );
            })
            .OrderByDescending(l => l.estimates)
            .Take(1)
            .ToList()
            .ForEach(l => System.Console.WriteLine(l));
            System.Console.WriteLine("----------------------------");
            System.Console.WriteLine("Lowest Ratio in 2015:\n");
            file
            .Skip(1)
            .Select(l => {
                var tokens = l.Split(",");
                return(
                    country: tokens[0],
                    year: tokens[2],
                    estimates: tokens[3]

                );
            })
            .Where(l => l.year == "2015")
            .OrderBy(l => l.estimates)
            .Take(10)
            .ToList()
            .ForEach(l => System.Console.WriteLine(l));
            
            System.Console.WriteLine("----------------------------");
            System.Console.WriteLine("The most fall in Iran:\n");

            float a = 0, i = 0, b = 0;
            string year = "";
            file
            .Skip(1)
            .Select(l => {
                var tokens = l.Split(",");
                return(
                    country: tokens[0],
                    year: tokens[2],
                    estimates: tokens[3]

                );
            })
            .Where(l => l.country == "Iran")
            .ToList().ForEach(l => {
                if(i == 0 || float.Parse(l.estimates) - b < a)
                {
                    if(i != 0)
                        a = float.Parse(l.estimates) - b;
                    year = l.year;
                }
            b = float.Parse(l.estimates);
            i++;});

            file
            .Select(l => {var tokens = l.Split(",");
            return (tokens[0], tokens[2], tokens[3]);
            })
            .Where(l => l.Item2 == year && l.Item1 == "Iran")
            .ToList().ForEach(l => System.Console.WriteLine(l));
        }
    }
}
