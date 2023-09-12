using System;
using System.IO;

namespace A3_cs
{
    internal class Enigma
    {
        private string dir;
        public int panzers = 0;
        public int bombers = 0;
        public double infantries = 0;
        public string[] lines;
        public Enigma(string dir)
        {
            this.dir = dir;
            this.lines = File.ReadAllLines(dir);
        }
        public void initialize()
        {
            if(this.lines[3].IndexOf("panzers") > 0)
            {
                int i = this.lines[3].IndexOf(" panzers") - 1;
                while(int.TryParse(char.ToString(this.lines[3][i]),out this.panzers))
                    i--;
                this.panzers = int.Parse(this.lines[3].Substring(i+1, this.lines[3].IndexOf(" panzers")-i-1).ToString());
            }
            if(this.lines[3].IndexOf("bombers") > 0)
            {
                int i = this.lines[3].IndexOf(" bombers") - 1;
                while(int.TryParse(char.ToString(this.lines[3][i]),out this.bombers))
                    i--;
                this.bombers = int.Parse(this.lines[3].Substring(i+1, this.lines[3].IndexOf(" bombers")-i-1).ToString());
            }
            if(this.lines[3].IndexOf("infantries") > 0)
            {
                int i = this.lines[3].IndexOf(" infantries") - 1;
                while(int.TryParse(char.ToString(this.lines[3][i]),out int k))
                    i--;
                this.infantries = double.Parse(this.lines[3].Substring(i+1, this.lines[3].IndexOf(" infantries")-i-1).ToString());
            }
        }
        public void Decode()
        {
            for(int i = 0; i < this.lines.Length; i++)
                this.lines[i] = this.lines[i].ToLower();

            string [] b = 
            {"  a.m. February",
            "from : Commander-in-chief",
            "target",
            "militaries",
            "dispatch as soon as it possible",
            "heil wizard"};
            for(int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < b[i].Length; j++)
                {
                    if((i != 0 || j != 0) && (this.lines[i][j]) != char.ToUpper(b[i][j]))
                    {
                        char old = this.lines[i][j];
                        char neww = char.ToUpper(b[i][j]);

                        for(int k = 0; k < this.lines.Length; k++)
                            this.lines[k] = this.lines[k].Replace(old,neww);   
                    }
                }
            }
            if(this.lines[1].Substring(27, 2) == "OE")
                    this.lines[1] = this.lines[1].Substring(0,26) + "JOE";

            for(int i = 0; i < this.lines.Length; i++)
            {
                this.lines[i] = this.lines[i].ToLower();

                for(int j = 0; j < this.lines[i].Length; j++){

                    if((j == 0 || this.lines[i][j-1] == ' ' || this.lines[i][j-1] == '.') && ((i != 3 && i != 4) || j == 0))
                        this.lines[i] = this.lines[i].Substring(0,j) + char.ToUpper(this.lines[i][j]) + this.lines[i].Substring(j+1);
                }
            }
            initialize();

            int c = (int)(10 - this.infantries%10);
            for(int i = 0; i < 4; i++)
            {
            for (int p = 0; p < this.lines[i].Length; p++)
                {
                    if((i == 0 || i == 3) && int.TryParse(this.lines[i][p].ToString(),out int j))
                        this.lines[i] = this.lines[i].Substring(0,p) + ((j + c)%10).ToString() + this.lines[i].Substring(p+1);
                }
            }    
        }

        public void Letter()
        {
            initialize();
            string letter = "Output\\"+Path.GetFileName(this.dir);
            string[] a = {this.lines[0].Substring(0,15), "Their Target is " + lines[2].Split(" : ")[1] + "\nThe required Militaries: "+ this.panzers*2 +" panzers," + this.bombers*3 + " bombers," + (int)(this.infantries*1.1) +" infantries"};
            File.WriteAllLines(letter, a);
        }
    }
}