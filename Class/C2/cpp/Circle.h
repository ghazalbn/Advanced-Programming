#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
using namespace std;
class Circle
{
    private:
    int CenterX;
    int CenterY;
    int Radius;

    public:

    Circle(int x,int y,int r)
    {
        CenterX = x;
        CenterY = y;
        Radius = r;
    }
    double Area()
    {
        return pow(Radius,2)*(M_PI);
    }
    double Circumference()
    {
        return 2*M_PI*Radius;
    }
    double DistanceFromCenter(Circle c)
    {
        return pow(pow(c.CenterX-CenterX,2)+pow(c.CenterY-CenterY,2),0.5);
    }
    
};
