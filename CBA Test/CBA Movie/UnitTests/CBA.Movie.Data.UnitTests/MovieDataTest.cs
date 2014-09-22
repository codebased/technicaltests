using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesLibrary;

namespace CBA.Movie.Data.UnitTests
{
    [TestClass]
    public class MovieDataTest
    {
        [TestMethod]
        public void CreateMovieDataTest()
        {
            MovieDataProvider dataProvider = new MovieDataProvider();
            int movieID = dataProvider.CreateMovie(new MovieData() { Title = "Test Title", Cast = new[] { "Test Cast1", "Test Cast 2" }, Classification = "Test Classification", Genre = "Test Genre", Rating = 5, ReleaseDate = (int)DateTime.Now.Ticks });

            Assert.AreNotEqual(0, movieID);
        }

        [TestMethod]
        public void GetMovieDataTest()
        {
            MovieDataProvider dataProvider = new MovieDataProvider();
            int movieID = dataProvider.CreateMovie(new MovieData() { Title = "Test Title", Cast = new[] { "Test Cast1", "Test Cast 2" }, Classification = "Test Classification", Genre = "Test Genre", Rating = 5, ReleaseDate = (int)DateTime.Now.Ticks });

            Assert.AreNotEqual(0, movieID);
            MovieData movieData = dataProvider.GetMovie(movieID);

            Assert.IsNotNull(movieData);
            Assert.AreEqual(movieData.MovieId, movieID);
        }

        [TestMethod]
        public void UpdateMovieDataTest()
        {
            MovieDataProvider dataProvider = new MovieDataProvider();
            int movieID = dataProvider.CreateMovie(new MovieData() { Title = "Test Title", Cast = new[] { "Test Cast1", "Test Cast 2" }, Classification = "Test Classification", Genre = "Test Genre", Rating = 5, ReleaseDate = (int)DateTime.Now.Ticks });

            Assert.AreNotEqual(0, movieID);
            MovieData movieData = dataProvider.GetMovie(movieID);

            movieData.Title = "Test Title Changed";
            dataProvider.UpdateMovie(movieData);

            MovieData updatedMovieData = dataProvider.GetMovie(movieID);

            Assert.AreEqual("Test Title Changed", updatedMovieData.Title, true );
        }

    }
}