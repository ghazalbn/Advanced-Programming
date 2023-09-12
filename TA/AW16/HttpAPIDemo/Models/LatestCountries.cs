using System;

public class LatestCounties
{
    public string country{get; set;}
    public string code{get; set;}
    public long confirmed{get; set;}
    public long recovered{get; set;}
    public long critical{get; set;}
    public long deaths{get; set;}
    public double latitude{get; set;}
    public double longitude{get; set;}
    public DateTime lastChange{get; set;}
    public DateTime lastUpdate{get; set;}
    public string[] Information()
    {
        return new string[]
        {
            $"code: {code}",
            $"confirmed: {confirmed}",
            $"recovered:{recovered}",
            $"critical: {critical}",
            $"deaths: {deaths}",
            $"latitude: {latitude}",
            $"longitude: {longitude}",
            $"last change: {lastChange}",
            $"last update: {lastUpdate}"
        };
    }
}