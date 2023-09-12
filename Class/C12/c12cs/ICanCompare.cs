namespace c12cs
{
    public interface ICanCompare<_Type>
    {
        bool IsGreaterThan(_Type other);
    }
}