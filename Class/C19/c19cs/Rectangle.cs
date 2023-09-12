using System;
using System.Drawing;

namespace c19cs
{
    internal class Rectangle: Shape
    {
        private Point[] Points = new Point[4];

        public Rectangle(string name, ConsoleColor color, Point[] points)
            : base(name, color)
        => Points = points;


        public override void Draw()
        {
            var cf = Console.ForegroundColor;
            base.SetColor();
            Console.WriteLine($"Drawing Rectangle ({Name})");
            Console.ForegroundColor = cf;
        }
        public override double Area 
        {
            get
            {
                double a = 0;
                for(int i = 0; i < Points.Length -1; i++)
                    a += new Triangle("A", ConsoleColor.Red, 
                    new Point[]{Points[0], Points[i], Points[i+1]}).Area;
                return Math.Round(a, 3);
            }
        }
        public override double Perimiter 
        {
            get
            {
                double s = Points[Points.Length -1].Distance(Points[0]);
                for(int i = 0; i < Points.Length -1; i++)
                    s += Points[i].Distance(Points[i+1]);
                return Math.Round(s, 3);
            }
        }
    }
}