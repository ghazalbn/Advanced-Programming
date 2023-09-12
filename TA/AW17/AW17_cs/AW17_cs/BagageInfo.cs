public class BagageInfo
{
    int flightNo;
    string origin;
    int location;
    public BagageInfo(int f, string o, int l)
        => (flightNo, origin, location) = (f, o, l);
    public int flightNumber
        {get => flightNo;}
    public string Origin
        {get => origin;}
    public int Location
        {get => location;}
}