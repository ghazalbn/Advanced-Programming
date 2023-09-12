namespace c13cs
{
    internal interface IStopwatch
    {
        void Start();
        void Mark(string name);
        void Stop();
    }
}