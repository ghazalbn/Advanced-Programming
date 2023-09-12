using System;
using System.IO;

namespace A3_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var text in Directory.GetFiles("Input"))
            {
                Enigma t = new Enigma(dir : text);
                t.Decode();
                t.Letter();
            }
        }
    }
}