#include <vector>
#include<iostream>
using namespace std;
namespace A1{
    template<typename T,typename... Type>
T MaximumValue(Type ... args)
    {
        vector<T> vlist = {args ...};
        T max = vlist[0];
        for(T i : vlist)
        {
            if(i > max) max = i;
        }
        return max;
    }
    void Sort(vector<int> &list)
    {
        for (int i = 0; i < list.size(); i++)
        {
            for (int j = i+1; j < list.size(); j++)
            {
                if(list[j] < list[i])
                swap(list[j], list[i]);
            }
        }
    }
    vector<int> CommonIntegerElements(int a[], int b[],int n,int m)
    {
        vector<int> list;
        for (int i = 0; i< n; i++) {
            for (int j =0; j < m;j++) {
                if (a[i] == b[j]) {
                    list.push_back(a[i]);
                    break;
                }
            }
        }
        Sort(list);
        return list;
    }
    void Sort(vector<string>& str)
    {
        for (int i = 0; i < str.size(); i++)
        {
            string min = str[i];
            for (int j = i+1; j < str.size(); j++)
            {
                if(str[j].size() < str[i].size()) min = str[j];

                for(int k = 0; k< min.size(); k++){
                if((int)str[j][k] < (int)str[i][k]){
                swap(str[i],str[j]);
                break;
                }
                else if((int)str[j][k] > (int)str[i][0])
                break;
                }
            }
        }
    }
    vector<string> CommonStringElements(string a[], string b[],int n,int m)
    {
        vector<string> str;
        for (int i = 0; i< n; i++) {
            for (int j =0; j < m;j++) {
                if (a[i] == b[j]) {
                    str.push_back(a[i]);
                }
            }
        }
        Sort(str);
        return str;
    }
    template<typename _Type> vector<_Type> CommonElements(_Type a[], _Type b[],int n, int m)
    {
        vector<_Type> list;
        for (int i = 0; i< n; i++) {
            for (int j =0; j < m;j++) {
                if (a[i] == b[j]) {
                    list.push_back(a[i]);
                    break;
                }
            }
        }
        return list;
    }
    }


