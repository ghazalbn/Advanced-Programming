namespace c12cs
{
    public interface IPointComparer
    {
        bool IsGreater(Point p1, Point p2);
    }

   public class PointXComparer: IPointComparer
    {
        public bool IsGreater(Point p1, Point p2) => p1.x > p2.x;
    }

    public class PointYComparer: IPointComparer
    {
        public bool IsGreater(Point p1, Point p2) => p1.y > p2.y;
    }

    public class PointManitudeComparer : IPointComparer
    {
        public bool IsGreater(Point p1, Point p2)
        => p1.x*p1.x+p1.y*p1.y > p2.x*p2.x+p2.y*p2.y;
    }


    public static class PointComparer
    {
        public static PointManitudeComparer PointManitudeComparer = new PointManitudeComparer();
        public static PointXComparer PointXComparer = new PointXComparer();
        public static PointYComparer PointYComparer = new PointYComparer();
    }
}