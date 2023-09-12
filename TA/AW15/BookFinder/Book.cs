using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder
{
    public class Book
    {
        public string[] Text{get; private set;}
        public string Name{get; private set;}
        public static string[] positive = File.ReadAllLines
                            ("..\\BookFinder\\words\\positive-words.txt");
        public static string[] negative = File.ReadAllLines
                            ("..\\BookFinder\\words\\negative-words.txt");
        public async Task BookInit(string name)
        {
            string b = "";
            try
            {
                var book = Directory.GetFiles("..\\BookFinder\\books", $"{name}.txt");
                if(book.Length < 1)
                {
                    await Task.Run(() => {
                        foreach (var txt in Directory.GetFiles("..\\BookFinder\\books"))
                        {
                            if(Path.GetFileName(txt).Replace(".txt","").ToLower().Contains(name.ToLower()))
                            {
                                b = txt;
                                break;
                            }
                        }
                    });
                }
                else b =book[0];
                if(!string.IsNullOrEmpty(b))
                {
                    Text = File.ReadAllLines(b);
                    Name = Path.GetFileName(b).Replace(".txt","");
                }
                else (Name, Text) = (null, null);
            }
            catch{}
        }
        public string words()
        {
            string w = "";
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                w += Text[i] + "\n";
                if(string.IsNullOrEmpty(Text[i]) || string.IsNullOrWhiteSpace(Text[i]))
                    length++;
            }
            return w;
        }
        public async Task<(long, long, long)> posNegWords(string text)
        {
            var s = await Task.Run(() => text.Split()
            .Where(s => !string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim('\\','.','?','"',')','(', ',').ToLower())
            );
            long a = s.Count();
            long p = s.Where(s => positive.Contains(s)).Count();
            long n = s.Where(s => negative.Contains(s)).Count();
            return (a, p, n);
        }
    }
}
