using System;
using System.Collections.Generic;
using System.IO;

namespace c7cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Data,double> dict = new Dictionary<Data, double>();
            dict = LoadData("children-per-woman-UN.csv");

            while(true)
            {
                Console.Write("country? ");
                string C = Console.ReadLine();
                Console.Write("Year? ");
                int Y = int.Parse(Console.ReadLine());
                Data d = new Data(country: C, year: Y);
                System.Console.WriteLine();
                System.Console.WriteLine(dict[d]);
                System.Console.WriteLine("****************\n");
            }
        }

        public static Dictionary<Data, double> LoadData(string file)
        {
            Dictionary<Data,double> dict = new Dictionary<Data, double>();

            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if(lines[0] != line)
                {
                    Data d = new Data(country: line.Split(',')[0] ,year: int.Parse(line.Split(',')[2]));
                    dict[d] = double.Parse(line.Split(',')[3]);
                }
            }
            return dict;
        }
    }
}
