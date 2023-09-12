using System;

namespace c19cs
{
    internal class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Distance(Point other)
            => Math.Pow(Math.Pow(x-other.x, 2) + Math.Pow(y-other.y, 2), 0.5);
    }
}