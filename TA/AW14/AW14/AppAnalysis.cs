using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AW14
{
    public class AppAnalysis
    {
        public List<AppData> Apps=new List<AppData>();
        public AppAnalysis()
        { }

        
        public static AppAnalysis AppAnalysisFactory(string csvAddress)
        {
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                int i = 0;
                while (!parser.EndOfData)
                {
                    i++;
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            }
            return appAnalysis;
        }

        public void AppendApp(string[] fields)
        {
            AppData ap = new AppData(fields);
            this.Apps.Add(ap);
        }

        public int AllAppsCount()
            => Apps.Count;

        public object AppsAboveXRatingCount(double x)
            => Apps.Where(l => l.Rating >= x).Count();

        public string RecentlyUpdatedCount(DateTime dateTime)
            => Apps.Where(l => l.LastUpdate >= dateTime)
            .Count().ToString();

        public string RecentlyUpdatedFreqCat(DateTime dateTime)
            => Apps.Where(l => l.LastUpdate > dateTime)
            .GroupBy(l => l.Category).OrderByDescending(l => l.Count())
            .First().Key;

        public List<string> MostRatedCategories(double x, int n)
            => Apps.Where(l => l.Rating > x).GroupBy(l => l.Category)
            .OrderByDescending(l => l.Count()).Select(g => g.Key)
            .Take(n).ToList();

        public Tuple<string,string> ExtremeMeanUpdateElapse()
        {
            var cat = Apps.GroupBy(l => l.Category)
            .OrderByDescending(g => g.Average(l => DateTime.Now.Ticks - l.LastUpdate.Ticks))
            .Select(l => l.Key);
            return (cat.Last(), cat.First()).ToTuple();
        }

        public double TopQuarterBoundary()
        {
            double[] apps = Apps.Where(l => l.Category == "PHOTOGRAPHY")
            .OrderByDescending(l => l.Rating).Select(l => l.Rating)
            .ToArray();
            return apps[apps.Length/4];
        }

        public List<string> XMostProfitables(int x)
            => Apps.Where(l => l.IsFree != 1)
            .OrderByDescending(l => l.Installs*l.Price)
            .Select(l => l.Name).Take(x).ToList();

        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
            => Apps.OrderBy(l => criteria(l))
            .Take(x).Select(l => l.Name).ToList();
    }
}
