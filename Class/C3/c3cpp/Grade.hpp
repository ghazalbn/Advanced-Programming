#include<string>
#include<iostream>
using namespace std;
class Grade
{
public:
    string name;
    double m_Value;
    int m_Credit;
    Grade(string n,double v,int c)
    {

        name = n;
        m_Value = v;
        m_Credit = c;
    }
    // string GetInfo()
    // {
    //     string s1;
    //     s1 = name+' ' + string(m_Credit) + " : " + string(m_Value)+'/n';
    //     return s1;
    // }
};