using System;
using System.IO;

namespace BookFinder
{
    public class Book
    {
        public string Text{get; private set;}
        public string Name{get; private set;}
        public Book(string name)
            {
                try
                {
                    var book = Directory.GetFiles("..\\BookFinder\\books", $"{name}.txt");
                    if(book.Length > 0)
                    {
                        Text = File.ReadAllText(book[0]);
                        Name = Path.GetFileName(book[0]).Replace(".txt","");
                    }
                }
                catch(Exception){}
            }
        public string words()
        {
            string  word = "";
            int i = 0;
            int length = 25;
            while(i<length)
            {
                string[] w = Text.Split();
                word += w[i];
                if(w[i] != "\n" && w[i] != "")
                    word += " ";
                else length++;
                i++;
            }
            return word; 
        }
    }
}
