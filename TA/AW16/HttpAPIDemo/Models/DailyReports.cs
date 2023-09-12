using System;

public class DailyReports
{
    public long confirmed{get; set;}
    public long recovered{get; set;}
    public long deaths{get; set;}
    public long active{get; set;}
    public string[] Information()
    {
        return new string[]
        {
            $"confirmed: {confirmed}",
            $"recovered:{recovered}",
            $"deaths: {deaths}",
            $"active: {active}",
        };
    }
}