/*
 * This Java source file was generated by the Gradle 'init' task.
 */
package A1;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

public class Program {
    public static int MaximumValue(int ... a)
    {
        int max = a[0];
        for (int i : a) {
            if(i > max)
            max = i;
        }
        return max;
    }
    public static void Sort(Integer[] list)
        {
            for (int i = 0; i < list.length; i++)
            {
                for (int j = i+1; j < list.length; j++)
                {
                    if(list[j] < list[i])
                    {
                        int t = list[i];
                        list[i] = list[j];
                        list[j] = t;
                    }
                }
            }
        }
    public static Integer[] CommonIntegerElements(Integer[] nums1, Integer[] nums2)
    {
        ArrayList<Integer> list = new ArrayList<Integer>();
        int k = 0;
        for (int i : nums1) {
            for (int j : nums2) {
                if (i == j) {
                    list.add(i);
                    k++;
                }
            }
        }
        Integer[] list1 = new Integer[k];
        for (int i = 0; i < k; i++)
            list1[i] = list.get(i);
        // Arrays.sort(list1);
        Sort(list1);
        return list1;
    }
        public static void Sort(String[] list)
        {
            for (int i = 0; i < list.length; i++)
            {
                String min = list[i];
                for (int j = i+1; j < list.length; j++)
                {
                    if(list[j].length()<list[i].length()) min = list[j];

                    for(int k = 0; k< min.length(); k++){
                    if((int)(list[j].charAt(k)) < (int)(list[i].charAt(k))){
                    String c = list[i];
                    list[i] = list[j];
                    list[j] = c;
                    break;
                    }
                    else if((int)(list[j].charAt(k)) > (int)(list[i].charAt(k)))
                    break;
                    }
                }
            }
        }
    public static String[] CommonStringElements(String[] a, String[] b)
        {
            ArrayList<String> str = new ArrayList<String>();
            int k = 0;
            for(String i : a)
            {
                for(String j : b)
                {
                if(i == j){
                str.add(i);
                k++;
                break;
                }
                }
            }
            String[] s = new String[k];
            for (int i = 0; i < k; i++)
                s[i] = str.get(i);
            // Arrays.sort(s);
            Sort(s);
            return s;
        }
        public static <_Type> ArrayList<_Type> CommonElements(_Type[] a, _Type[] b)
        {
            ArrayList<_Type> list = new ArrayList<_Type>();
            for(_Type i : a)
            {
               for(_Type j : b)
               {
                   if(i == j) {
                   list.add(i);
                   break;
                   }
               }
            }
            return list;
        }
    public static void main(String[] args) {
        
    }
}
