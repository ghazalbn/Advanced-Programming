using System;

namespace c12cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(x:1, y:12);
            Point p1 = new Point(x:3, y:2);
            Point p2 = new Point(x:1, y:15);
            Point p3 = new Point(x:5, y:2);
            Point[] points = new Point[]{p,p1,p2,p3};

            Sort(points, PointComparer.PointXComparer);
            foreach (Point pi in points)
                System.Console.WriteLine($"({pi.x},{pi.y})");
            System.Console.WriteLine("---------------");

            Sort(points, PointComparer.PointYComparer);
            foreach (Point pi in points)
                System.Console.WriteLine($"({pi.x},{pi.y})");
            System.Console.WriteLine("---------------");

            Sort(points, PointComparer.PointManitudeComparer);
            foreach (Point pi in points)
                System.Console.WriteLine($"({pi.x},{pi.y})");
            System.Console.WriteLine("---------------");
            
            Sort<Point>(points);
            foreach (Point pi in points)
                System.Console.WriteLine($"({pi.x},{pi.y})");
            System.Console.WriteLine("---------------");
        }

        static void Sort(Point[] points, IPointComparer cmd)
        {
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (cmd.IsGreater(points[i],points[j]))
                    {
                        Point temp = points[j];
                        points[j] = points[i];
                        points[i] = temp;
                    }
                }
            }
 
        }

        // Optional
        static void Sort<_Type>(_Type[] elements) where _Type: ICanCompare<_Type>
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[i].IsGreaterThan(elements[j]))
                    {
                        _Type temp = elements[j];
                        elements[j] = elements[i];
                        elements[i] = temp;
                    }
                }
            }
        }
    }
}
