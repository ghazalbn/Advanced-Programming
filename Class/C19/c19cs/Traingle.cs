using System;
using System.Drawing;

namespace c19cs
{
    internal class Triangle: Shape
    {
        private Point[] Points = new Point[3];

        public Triangle(string name, ConsoleColor color, Point[] points)
            : base(name, color)
        => Points = points;

        public override void Draw()
        {
            var cf = Console.ForegroundColor;
            base.SetColor();
            Console.WriteLine($"Drawing Triangle ({Name})");
            Console.ForegroundColor = cf;
        }
        public override double Area 
        {
            get
            {
                return Math.Abs(Points[0].x*(Points[1].y - Points[2].y)
                + Points[1].x*(Points[2].y - Points[0].y)
                + Points[2].x*(Points[0].y - Points[1].y))/2;
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