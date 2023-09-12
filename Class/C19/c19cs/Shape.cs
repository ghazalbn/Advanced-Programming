using System;
using System.Drawing;

namespace c19cs
{
    abstract class Shape
    {
        protected string Name;
        protected ConsoleColor Color;

        public Shape(string name, ConsoleColor c)
            => (Color, Name) = (c, name);

        public abstract void Draw();
        public void SetColor()
            => Console.ForegroundColor = Color;

        public void PrintInfo()
            => Console.WriteLine
            ($"Info:\nType: {this.GetType().Name}\nName: {Name},\nColor: {Color},\nArea: {Area},\nPerimiter: {Perimiter}");
        
        public abstract double Area {get;}
        public abstract double Perimiter {get;}
        
    }
}