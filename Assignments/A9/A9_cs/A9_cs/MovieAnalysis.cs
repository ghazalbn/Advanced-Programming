using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A9_cs
{
    public class MovieAnalysis
    {
        public MovieData[] MovieDatas;
        public MovieAnalysis(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<MovieData> Movies = new List<MovieData>();
            for (int i = 1; i < lines.Length - 1; i++)
                try
                {
                    var t = new MovieData(lines[i].Replace(" ", "").Split(','));
                    Movies.Add(t);
                }
                catch { }
            this.MovieDatas = Movies.ToArray();
        }
        //اطلاعات فیلم ها در آرایه ی MovieDatas ذخیره شده اند
        public long AllDataCount()
            => MovieDatas.Length;
        public long AllMoviesIn2014()
            => MovieDatas.Count(l => l.year == 2014);
        public string[] AllAmbiguous()
            => MovieDatas.Where(m => m.color == MovieColor.Ambigous)
                .Select(l => l.movie_title).ToArray();
        public string MostDirector()
            => MovieDatas.GroupBy(l => l.directorName)
            .Aggregate((g1,g2) => 
            (g1.Count() > g2.Count()) ? g1: g2).Key;
        public string[] FiveBestMovies()
            => MovieDatas.OrderByDescending(l => l.imdb_score)
            .Take(5).Select(l => $"{l.movie_title} {l.year}")
            .ToArray();
        public string DirectorWithMaximomDuration()
            => MovieDatas.GroupBy(l => l.directorName)
            .Select(g => $"{g.Key} {g.Sum(l => l.duration)}")
            .OrderByDescending(l => double.Parse(l.Split()[1]))
            .First();
        public Tuple<string, string> MinMaxCriticMovie()
        {
            string[] titles = MovieDatas.OrderByDescending(l => l.num_critic)
            .Select(l => l.movie_title).ToArray();
            return (titles.First(), titles.Last()).ToTuple();
        }
        public long? YearWithMostMovies()
            => MovieDatas.GroupBy(l => l.year)
            .OrderByDescending(l => l.Count())
            .First().Key;
        public string MostEfficientMovie()
            => MovieDatas.Aggregate((m1, m2) => 
            (double)m1.budget/m1.imdb_score> (double)m2.budget/m2.imdb_score?
            m2 : m1).movie_title;
        public string[] MoviesAppropriate(ContentRating cr)
            => MovieDatas
            .Where(l => l.content_rating == cr && l.language == "English")
            .OrderByDescending(l => l.year).Take(3).Select(l => l.movie_title)
            .ToArray();
        public string[] BestDirectorName()
            => MovieDatas.Where(l => l.country == "Iran")
            .GroupBy(l => l.directorName)
            .OrderByDescending(g => g.Average(l => l.imdb_score))
            .Take(2).Select(l => l.Key).ToArray();
        public string MostActorMovie()
        {
            IDictionary<string, int> actors = new Dictionary<string, int>();
            MovieDatas
            .Select(m => (a1: m.actor_1_name, a2: m.actor_2_name, a3: m.actor_3_name))
            .ToList().ForEach(m => {
            actors[m.a1] = (actors.ContainsKey(m.a1)? actors[m.a1]+1:1);
            actors[m.a2] = (actors.ContainsKey(m.a2)? actors[m.a2]+1:1);
            actors[m.a3] = (actors.ContainsKey(m.a3)? actors[m.a3]+1:1);});
            return actors.Aggregate((a1, a2) => a1.Value>a2.Value? a1:a2).Key;
        }
        public string ActionMovies()
            => MovieDatas.Where(m => m.genres.Contains("Action"))
            .OrderByDescending(m => m.imdb_score).Take(3)
            .Select(m => m.movie_title)
            .Aggregate((m1, m2) => m1 + " " + m2);
        public double? DramaMoviesOfJohnnyDepp()
            => MovieDatas
            .Where(m => m.actor_1_name == "JohnnyDepp"
            && m.genres.Contains("Drama"))
            .Average(m => m.budget);
    }
}
