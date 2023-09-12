#include <cmath>
#include "Circle.h"
using namespace std;
int main(int argc, char const *argv[])
{
    Circle c(2,3,4);
    cout<< c.Area() <<endl;
    cout<< c.Circumference();
    return 0;
}
