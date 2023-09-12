using System;
using System.Collections.Generic;
using System.IO;

namespace c6cs
{
    internal class TextIndex
    {
        private string dir;
        private Dictionary<string, List<string>> Index;
        public TextIndex(string d)
        {
            this.dir = d;
            this.Index = new Dictionary<string, List<string>>();
        }

        public void BuildIndex(string filter)
        {
            foreach (var text in Directory.GetFiles(dir, filter))
            {
                string [] tokens = File.ReadAllText(text).Split(',','.',' ','?','!','\'','-','#','(',')','&','"');
                foreach(var token in tokens)
                {
                    if(!string.IsNullOrWhiteSpace(token))
                    {
                        if(!this.Index.ContainsKey(token))
                            this.Index[token] = new List<string>();
                        this.Index[token].Add(Path.GetFileName(text));
                    }
                }
            }
        }

        public List<string> Query(string query)
        {
            if(this.Index.ContainsKey(query)){
                return this.Index[query];
            }
            return new List<string>();
        }
    }
}