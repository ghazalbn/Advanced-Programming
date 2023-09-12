using System;
using System.Collections.Generic;
using System.Linq;
public class Monitor : IObserver<BagageInfo>
{
    private string name;
    private List<string> flightInfos = new List<string>();
    public IDisposable Cancel { get; private set; }
    public virtual void Subscribe(BagageHandler provider)
    => Cancel = provider.Subscribe(this);
    public virtual void UnSubscribe()
    => Cancel.Dispose();
    public void OnCompleted()
        => flightInfos.Clear();
    public Monitor(string n)
        => name = n;

    public void OnError(Exception error){}
    public void OnNext(BagageInfo value)
    {
        if(value.Location == 0)
        {
            List<string> Remove = new List<string>();
                foreach(var flightInfo in flightInfos)
                {
                    if(flightInfo.Equals(value.flightNumber))
                    {
                        Remove.Add(flightInfo);
                    }
                }
        }
        else
        {
            string flightInfo = value.Origin + value.flightNumber + value.Location;
            if(!flightInfo.Contains(flightInfo))
                flightInfos.Add(flightInfo);
        }
        Console.WriteLine($"Arrival Information From {name}:");
        flightInfos.ForEach(f => Console.WriteLine(f));

    }
}