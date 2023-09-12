#include<string>
#include<iostream>
#include<time.h>
using namespace std;

static int Timer_count = 0;

class Timer
{
public:    
    int local_timer_count = Timer_count;
    string Label;
    clock_t c;

    Timer(string label)
    {
        Label = label;
        c = clock();
        
        for (int i = 0; i < local_timer_count; i++) cout<<"     ";
        
        cout<<"Started "<<label<<endl;
        Timer_count ++;
    }
    ~Timer()
    {

        double d = clock() - c;
        for (int i = 0; i < local_timer_count; i++) cout<<"     ";
        cout<<"Ended "<<Label<<": Time: "<<d<<"ms"<<endl;
        Timer_count -- ;

    }
};

