using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cs
{
    class Program
    {
        const string StorageFileName = "phonenumbers.csv";
        static void Main(string[] args)
        {
            if(args.Length == 1 && args[0] == "add")
            addPerson();
            else if(args.Length == 1 && args[0] == "list")
            printNumbers();
            else if(args.Length != 0 && args[0] == "remove")
            {
            if(!removePerson(args))
            usage();
            }
            else if(args.Length != 0 && args[0] == "find")
            {
                if(!findNumber(args))
                usage();
            }
            else
            usage();
            
        }

        // remove nemikone!
        private static bool removePerson(string[] args)
        {
            if(args.Length != 2){
                Console.WriteLine("Person Not Found!");
                return false;
            }
            string searchKey = args[1].ToLower();

            string[] l = File.ReadAllLines(StorageFileName);
            var lines = l.ToList();
            foreach (string line in lines)
            {
                string[] tokens = line.ToLower().Split(" : ");
                string name = tokens[0];
                string number = tokens[1];
                if(name == searchKey || number == searchKey){
                    lines.Remove(line);
                    File.WriteAllLines(StorageFileName, lines);
                    Console.WriteLine($"{searchKey} removed from the list.");
                    return true;
                }
            }
            Console.WriteLine("Person Not Found!");

            return true;
        }

        private static bool findNumber(string[] args)
        {
            if(args.Length != 2){
                Console.WriteLine("Not Found!");
                return false;
            }
            string searchKey = args[1].ToLower();

            string[] lines = File.ReadAllLines(StorageFileName);
            bool found = false;
            foreach (string line in lines)
            {
                string[] tokens = line.ToLower().Split(" : ");
                string name = tokens[0];
                string number = tokens[1];
                if(name == searchKey){
                    Console.WriteLine(number);
                    found =true;
                }
            }
            if(!found)
            Console.WriteLine("Not Found!");

            return true;
        }

        private static void usage()
        {
            Console.WriteLine("The usage syntax is as follows:");
            Console.WriteLine("cs.exe add|list|find []|remove []");
        }

        private static void printNumbers()
        {
            Console.WriteLine(File.ReadAllText(StorageFileName));
        }

        public static void addPerson()
        {
            Console.Write("Phone Number? ");
            string number = Console.ReadLine();
            Console.Write("Name? ");
            string name = Console.ReadLine();
            File.AppendAllText(StorageFileName,$"{name} : {number}\n");
        }
    }
}
