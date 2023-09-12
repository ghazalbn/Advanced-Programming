namespace c12cs
{
    public class Point: ICanCompare<Point> // optional
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool IsGreaterThan(Point p)
        => this.x*this.x+this.y*this.y > p.x*p.x+p.y*p.y;
    }
}