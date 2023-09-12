using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder
{
    public class Book
    {
        public string[] Text{get; private set;}
        public string Name{get; private set;}
        public static HashSet<string> positive = 
        File.ReadAllLines("..\\BookFinder\\words\\positive-words.txt").ToHashSet();
        public static HashSet<string> negative = 
        File.ReadAllLines("..\\BookFinder\\words\\negative-words.txt").ToHashSet();
        public void BookInit(string name)
        {
            try
            {
                var books = Directory.GetFiles("..\\BookFinder\\books");
                var book = books.FirstOrDefault(b => Path.GetFileName(b)
                .Replace(".txt", "").ToLower().Contains(name.ToLower()));
                if(!string.IsNullOrEmpty(book))
                {
                    Text = File.ReadAllLines(book);
                    Name = Path.GetFileName(book).Replace(".txt","");
                }
                else (Name, Text) = (null, null);
            }
            catch{}
        }
        public string words()
            => Text.Where(t => !string.IsNullOrEmpty(t)).Take(4).Aggregate((l1,l2) => $"{l1} {l2}");
        public (long, long, long) posNegWords(string text)
        {
            var s = text.Split()
            .Where(s => !string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim('\\','.','?','"',')','(', ',').ToLower());
            long a = s.Count();
            long p = s.Where(s => positive.Contains(s)).Count();
            long n = s.Where(s => negative.Contains(s)).Count();
            return (a, p, n);
        }
    }
}
