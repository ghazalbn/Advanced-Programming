using System;

namespace AW2_cs
{
    class Max
    {
        static int maximum(params int[] list)
        {
            int max = list[0];
            foreach(int i in list)
            {
                
                if(i>max)
                    max = i;
            }
            return max;
        }
        static void Main(string[] args)
        {
           Console.WriteLine(maximum(1,87,95,6,43));
        }
    }
}
