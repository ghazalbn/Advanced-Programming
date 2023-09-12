using System;
using System.Collections.Generic;

internal class UnSubscribe<T> : IDisposable
{
    private List<IObserver<BagageInfo>> observers;
    private IObserver<BagageInfo> observer;

    public UnSubscribe(List<IObserver<BagageInfo>> observers, IObserver<BagageInfo> observer)
    {
        this.observers = observers;
        this.observer = observer;
    }

    public void Dispose()
    {
       if(observers.Contains(observer)) 
            observers.Remove(observer);
    }
}