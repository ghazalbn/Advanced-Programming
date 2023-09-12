namespace Exam1_cs
{
    public interface ILocatable
    {
        long X{get; set;}
        long Y{get; set;}
        long Z{get; set;}
        long Distance(ILocatable i);
    }
}