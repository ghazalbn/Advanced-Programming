using System;

namespace c10cs
{
    struct IntBit
    {
        public int Length;
        private int N;
        public IntBit(int n)
        {
            this.Length = 0;
            this.N = n;
            while(n != 0)
            {
                this.Length++;
                n = n>>1;
            }
        }
        public bool this[int n]
        {
            get
            {
                // return ((this.N & (1<<n))>>n) == 1;
                return ((this.N >> n) & 1) == 1;
            }
            set
            {
                if(value)
                    this.N = this.N | (1<<n);
                else
                    this.N = this.N & ~(1<<n);
            }
        }
 
        public static int operator+(IntBit lhs, IntBit rhs)
        {
            int s = 0;
            // lhs -> Number of On Bits
            for(int i=0; i<lhs.Length; i++)
            {
                if (lhs[i])
                    s++;
            }
            // rhs -> Number of On Bits
            for(int i=0; i<rhs.Length; i++)
            {
                if (rhs[i])
                    s++;
            }
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IntBit n = new IntBit(31);
            bool bit0 = n[0];
            n[4] = false; // 4 1
 
            IntBit n1 = new IntBit(64);
            bool b = n1[6];
            
            int w = n1 + n; /// 1 + 4 = 5
            System.Console.WriteLine(w);
            Console.ReadKey();
        }
    }
}