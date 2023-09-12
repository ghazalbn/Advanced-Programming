#include"Timer.hpp"
#include<iostream>
using namespace std;

void HeavyMethod()
{
    Timer t("HeavyMethod");
    long n = 10000000;
    int s = 0;
    for(int i = 0; i < n; i++) s++;
    int m = s/n;
}

int main(int argc, char const *argv[])
{
    Timer tmain("Main method");
    if(true)
    {
        Timer tif("if statement");
        for (int i = 0; i < 1; i++)
        {
            Timer tfor("for statement");
        }
        
    }
    HeavyMethod();
    return 0;
}
