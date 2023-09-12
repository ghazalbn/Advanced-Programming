namespace Exam1_cs
{
    public class Traffic
    {
        public Place source;
        public Place target;

        public Traffic(Place p1, Place p2)
        {
            this.source = p1;
            this.target = p2;
        }
    }
}