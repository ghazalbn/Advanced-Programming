using System;
class Circle
{
    int CenterX;
    int CenterY;
    int Radius;
    public Circle(int x,int y,int r)
    {
        CenterX = x;
        CenterY = y;
        Radius = r;
    }
    public double Area()
    {
        return Math.Pow(Radius,2)*Math.PI;
    }
    public double Circumference()
    {
        return 2*Math.PI*Radius;
    }
    public double DistanceFromCenter(Circle c)
    {
        return Math.Pow(Math.Pow(c.CenterX-this.CenterX,2)+Math.Pow(c.CenterY-this.CenterY,2),0.5);
    }
    
}
