using System;
using System.Drawing;

namespace c19cs
{
    internal class Square: Rectangle
    {
        private Point[] Points = new Point[4];
        public Square(string name, ConsoleColor color, Point[] points)
            : base(name, color, points){}
        

        public override void Draw()
        {
            var cf = Console.ForegroundColor;
            base.SetColor();
            Console.WriteLine($"Drawing Square ({Name})");
            Console.ForegroundColor = cf;
        }
    }
}