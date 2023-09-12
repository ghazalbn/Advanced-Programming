#include<string>
#include "Stat.hpp"
#include <iostream>
using namespace std;
int main(int argc, char const *argv[])
{
    Grade g1("math",18.8,3);
    Stat s;
    s.AddGrade(g1);
    s.AddGrade(Grade("pe",19.9,1));
    cout<<s.GetAverage()<<endl;
    return 0;
}
