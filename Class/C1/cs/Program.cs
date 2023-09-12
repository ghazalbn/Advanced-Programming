using System;

namespace cs
{
    class Program
    {
        
            static void Reverse<_Type>(_Type[] list)
            {
                for(int j = 0;j< list.Length/2;j++)
                {
                    _Type tmp = list[j];
                    list[j] = list[list.Length-j-1];
                    list[list.Length-j-1] = tmp;
                }
               
            }
            static void OutReverse<_Type>(params _Type[] list)
            {
                Reverse(list);
                int d = 0;
                foreach(_Type i in list)
                {
                    Console.Write(i);
                    if(d != list.Length-1)
                    Console.Write(',');
                    d++;
                }

            }
        static void Main(string[] args)
        {
        // int[] list = {1,2,3,4,5,6,7,8,9,10};
        OutReverse(1,2,3,4,5,6,7,8,9,10);
        Console.ReadLine();

        }   
    }
}
