using System;
using System.Drawing;

namespace c19cs
{
    internal class Circle: Shape
    {
        private Point center;
        private double radius;

        public Circle(string name, ConsoleColor color, Point center, double radius)
            : base(name, color)
        => (this.center, this.radius) = (center, radius);

        public override void Draw()
        {
            var cf = Console.ForegroundColor;
            base.SetColor();
            Console.WriteLine($"Drawing Circle ({Name})");
            Console.ForegroundColor = cf;
        }
        public override double Area 
        {
            get
            {
                return Math.Round(Math.PI*radius*radius, 3);
            }
        }
        public override double Perimiter 
        {
            get
            {
                return Math.Round(Math.PI*radius*2, 3);
            }
        }
    }
}