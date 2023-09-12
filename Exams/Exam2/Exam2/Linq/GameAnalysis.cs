using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exam2
{
    public class GameAnalysis
    {
        public GameData[] GameDatas;
        public GameAnalysis(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<GameData> Games = new List<GameData>();
            for (int i = 1; i < lines.Length - 1; i++)
                try
                {
                    var t = new GameData(lines[i].Replace(" ", "").Split(','));
                    Games.Add(t);
                }
                catch
                {
                    long o = 0;
                }
            GameDatas = Games.ToArray();
        }
        public long AllDataCount()
        => GameDatas.Count();
        public Tuple<string,long>[] MostFrequent()
        => GameDatas.GroupBy(g => g.genre)
            .OrderByDescending(g => g.Count()).Take(5)
            .Select(l => (l.Key, (long)l.Count()).ToTuple())
            .ToArray();
        public double[] BestPublisher()
        => GameDatas.Where(g => g.year >= 2000 && g.year <= 2010)
            .GroupBy(g => g.publisher).OrderByDescending(l => l.Count())
            .Take(5).Select(l => Math.Round(l.Average(g => g.Global_sales), 3))
            .ToArray();
        public string[] WestGamers(int limit1, int limit2)
        => GameDatas.OrderByDescending(g => g.EU_sales+g.NA_sales)
            .Skip(limit1-1).Take(limit2-limit1+1).Select(g => g.name)
            .ToArray();
        public string FaultyDatas()
        => GameDatas
            .Where(g => (g.EU_sales+g.JP_sales+g.NA_sales+g.Other_sales) != g.Global_sales)
            .OrderByDescending(g => g.year).Take(10).Select(g => g.name)
            .Aggregate((g1,g2) => $"{g1} {g2}").TrimEnd();
    }
}
