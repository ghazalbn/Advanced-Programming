using System;
using System.Collections.Generic;

public class BagageHandler: IObservable<BagageInfo>
{
    private List<IObserver<BagageInfo>> observers;
    private List<BagageInfo> flights;
    public BagageHandler()
        => (observers, flights) = (new List<IObserver<BagageInfo>>(), new List<BagageInfo>());

    public IDisposable Subscribe(IObserver<BagageInfo> observer)
    {
        if(observers.Contains(observer))
        {
            observers.Add(observer);
            flights.ForEach(f => observer.OnNext(f));
        }
        return new UnSubscribe<BagageInfo> (observers, observer);
    }
    public void BagageStatus(int flightNum,string from,int carousel)
    {
        BagageInfo info=new BagageInfo(flightNum,from,carousel);
        if(carousel>0 && !flights.Contains(info)){
            flights.Add(info);
            foreach(var observer in observers){
                observer.OnNext(info);
            }
        }
        else if(carousel==0){
            var removing =new List<BagageInfo>();
            foreach(var flight in flights){
                if(info.flightNumber==flight.flightNumber)
                {
                    removing.Add(flight);
                    foreach(var observer in observers){
                        observer.OnNext(info);
                    }
                }
            }
            foreach(var rmv in removing){
                flights.Remove(rmv);
            }
            removing.Clear();
        }
    }
    public void BagageStatus(int flightNo)
        => BagageStatus(flightNo,"",0);

    public void LastBagageClaimed()
    {
        observers.ForEach(o=>o.OnCompleted());
        observers.Clear();
    }
}