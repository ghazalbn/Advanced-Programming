using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;

namespace A9_cs.Tests
{
    [TestClass]
    public class MovieTests
    {
        MovieAnalysis mv = new MovieAnalysis(@"..\..\..\MovieDataSet.csv");

        [TestMethod]
        public void AllAppCounts_Test()
        {
            Assert.AreEqual(mv.AllDataCount(), 4252);
        }

        [TestMethod]
        public void AllMoviesIn2014_Test()
        {
            Assert.AreEqual(mv.AllMoviesIn2014(), 177);
        }

        [TestMethod]
        public void AllAmbiguous_Test()
        {
            string[] result = new string[]
            {
                "DearJohn",
                "ShinjukuIncident",
                "IntotheGrizzlyMaze",
                "SnowFlowerandtheSecretFan",
                "SmallApartments",
                "OnceUponaTimeinQueens"
            };
            CollectionAssert.AreEqual(mv.AllAmbiguous(), result);
        }
        [TestMethod]
        public void MostDirectorName_Test()
        {
            Assert.AreEqual(mv.MostDirector(), "StevenSpielberg");
        }
        [TestMethod]
        public void FiveBestMovies_Test()
        {
            string[] result = new string[]
            {
                "TheShawshankRedemption 1994",
                "TheGodfather 1972",
                "TheDarkKnight 2008",
                "TheGodfather:PartII 1974",
                "TheLordoftheRings:TheReturnoftheKing 2003"
            };
            string[] r = mv.FiveBestMovies();
            CollectionAssert.AreEqual(mv.FiveBestMovies(), result);
        }
        [TestMethod]
        public void DirectorWithMaximomDuration_Test()
        {
            Assert.AreEqual(mv.DirectorWithMaximomDuration(), "StevenSpielberg 3571");
        }
        [TestMethod]
        public void YearWithMostMovies_Test()
        {
            Assert.AreEqual(mv.YearWithMostMovies(), 2006);
        }
        [TestMethod]
        public void MostEfficientMovie_Test()
        {
            Assert.AreEqual(mv.MostEfficientMovie(), "Tarnation");
        }
        [TestMethod]
        public void MostCriticMovie_Test()
        {
            Assert.AreEqual(mv.MinMaxCriticMovie().Item1, "TheDarkKnightRises");
            Assert.AreEqual(mv.MinMaxCriticMovie().Item2, "DrySpell");
        }
        [TestMethod]
        public void MoviesAppropriate_Test()
        {
            string[] result = new string[]
            {
                "ThePeanutsMovie",
                "Rio2",
                "MonstersUniversity"
            };
            CollectionAssert.AreEqual(mv.MoviesAppropriate(ContentRating.G), result);
        }
        [TestMethod]
        public void BestDirectorName_Test()
        {
            string[] result = new string[]
            {
                "MajidMajidi",
                "AsgharFarhadi"
            };
            CollectionAssert.AreEqual(mv.BestDirectorName(), result);
        }
        [TestMethod]
        public void MostActorMovie_Test()
        {
            Assert.AreEqual(mv.MostActorMovie(), "RobertDeNiro");
        }
        [TestMethod]
        public void ActionMovies_Test()
        {
            Assert.AreEqual(mv.ActionMovies(), "TheDarkKnight TheLordoftheRings:TheReturnoftheKing Inception");
        }
        [TestMethod]
        public void DramaMoviesOfJohnnyDepp_Test()
        {
            Assert.AreEqual(mv.DramaMoviesOfJohnnyDepp(), 36406250);
        }

    }
}
