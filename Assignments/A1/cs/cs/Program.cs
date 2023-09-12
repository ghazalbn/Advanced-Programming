using System;
using System.Collections.Generic;  
namespace cs
{
    public class Program
    {
        public static void Let(out int n,ref int m) => n = m;
        public static void Square(ref int n) => n = n*n;
        
        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        public static void Swap(ref string a, ref string b)
        {
            string c = a;
            a = b;
            b = c;
        }
        public static void SwapArray(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Swap(ref a[i], ref b[i]);
            }
        }
        public static int MaximumValue(params int[] a)
        {
            int max = a[0];
            foreach (int i in a)
            {
                if(i > max) max = i;
            }
            return max;
        }
        public static void Sort(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i+1; j < list.Length; j++)
                {
                    if(list[j] < list[i])
                    Swap(ref list[j], ref list[i]);
                }
            }
        }
        public static void Sort(String[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                string min = list[i];
                for (int j = i+1; j < list.Length; j++)
                {
                    if(list[j].Length<list[i].Length) min = list[j];

                    for(int k = 0; k< min.Length; k++){
                    if((int)list[j][k] < (int)list[i][k]){
                    Swap(ref list[i],ref list[j]);
                    break;
                    }
                    else if((int)list[j][k] > (int)list[i][0])
                    break;
                    }
                }
            }
        }
        public static int[] CommonIntegerElements(int[] a, int[] b)
        {
            List<int> list = new List<int>();
            int k = 0;
            foreach (int i in a)
            {
               foreach (int j in b)
               {
                   if(i == j) {
                   list.Add(i);
                   k++;
                   break;
                   }
               }
            }
            // list.Sort();
            int[] list1 = new int[k];
            for (int i = 0; i < k; i++)
                list1[i] = list[i];
            Sort(list1);
            return list1;
        }
        public static string[] CommonStringElements(string[] a, string[] b)
        {
            List<string> str = new List<string>();
            int k = 0;
            foreach (string i in a)
            {
                foreach (string j in b)
                {
                if(i == j){
                str.Add(i);
                k++;
                break;
                }
                }
            }
            // str.Sort();
            string[] s = new string[k];
            for (int i = 0; i < k; i++)
                s[i] = str[i];
            Sort(s);
            return s;
        }
        public static _Type[] CommonElements<_Type>(_Type[] a, _Type[] b)
        {
            List<_Type> list = new List<_Type>();
            int k = 0;
            foreach (_Type i in a)
            {
               foreach (_Type j in b)
               {
                   if(i.Equals(j)) {
                   list.Add(i);
                   k++;
                   break;
                   }
               }
            }
            _Type[] list1 = new _Type[k];
            for (int i = 0; i < k; i++)
                list1[i] = list[i];
            return list1;
        }
        public static void Main()
        {
            
        }
    }
}
