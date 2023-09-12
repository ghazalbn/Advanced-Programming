using System;

namespace c6cs
{
    class Program
    {
        static void Main(string[] args)
        {

            TextIndex tiTrump = new TextIndex("Trump");
            TextIndex tiClinton = new TextIndex("Clinton");

            tiTrump.BuildIndex("*.txt");
            tiClinton.BuildIndex("*.txt");
            
            while(true)
            {
                Console.Write("Query? ");
                string query = Console.ReadLine();
                if(query == "exit")
                    break;
                System.Console.WriteLine($"Trump: {tiTrump.Query(query).Count}, Clinton: {tiClinton.Query(query).Count}");
            }
            }
        }
    }

