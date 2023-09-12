using System;
using System.IO;

namespace BookFinder
{
    public class Book
    {
        public string[] Text{get; private set;}
        public string Name{get; private set;}
        public (long, long, long) wordCount{get; private set;}
        public Book(string name)
            {
                string b = "";
                try
                {
                    var book = Directory.GetFiles("..\\BookFinder\\books", $"{name}.txt");
                    if(book.Length < 1)
                    {
                        foreach (var txt in Directory.GetFiles("..\\BookFinder\\books"))
                        {
                            if(Path.GetFileName(txt).Replace(".txt","").ToLower().Contains(name.ToLower()))
                            {
                                b = txt;
                                break;
                            }
                        }
                    }
                    else b =book[0];
                    Text = File.ReadAllLines(b);
                    Name = Path.GetFileName(b).Replace(".txt","");
                    wordCount = posNegWords(Text);
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
        public (long, long, long) posNegWords(string[] text)
        {
            long p = 0, n = 0, w = 0;
            string[] positive = File.ReadAllLines
                            ("..\\BookFinder\\words\\positive-words.txt");
            string[] negative = File.ReadAllLines
                            ("..\\BookFinder\\words\\negative-words.txt");
            foreach (var txt in text)
            {
                if(txt == null) break;
                string[] words = txt.Split();
                foreach (string word in words)
                {
                    string wrd = word.Replace("\\", "").Replace("/", "").Replace(".", "")
                    .Replace("?", "").Replace("(", "").Replace(")", "").Replace("*", "").ToLower();
                    if(!string.IsNullOrWhiteSpace(wrd) && !string.IsNullOrEmpty(wrd))
                    {
                        if(Array.IndexOf(positive, wrd) > 0)
                            p++;
                        else if(Array.IndexOf(negative, wrd)> 0)
                            n++;
                        w++;
                    }
                }
            }
            return (w ,p, n);
        }
    }
}
