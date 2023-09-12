namespace e6cs
{
    public interface IVector
    {
        int Length {get; }
        int this[int i] {get; set;}
        double Magnitude {get;}
    }
}