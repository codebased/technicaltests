using System;
using System.Collections.Generic;
using CBA.Movie.Data;
using CBA.Movie.WebApi.Core.Configuration;
using CBA.Movie.WebApi.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CBA.Movie.WebApi.Core.Tests
{
    [TestClass]
    public class MovieServiceTest
    {
        [TestInitialize]
        public void Initialize()
        {
            DtoMapperConfig.CreateMaps();
        }

        [TestMethod]
        public void GetMovieServiceTest()
        {
            Service.MovieService movieService = new Service.MovieService(new MovieDataProvider());
            var data = movieService.Get(null);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void PostMovieServiceTest()
        {
            Service.MovieService movieService = new Service.MovieService(new MovieDataProvider());
            var movieData = movieService.Post(new Dto.MovieDto() { Title = "Test Title", Cast = new[] { "Test Cast1", "Test Cast 2" }, Classification = "Test Classification", Genre = "Test Genre", Rating = 5, ReleaseDate = (int)DateTime.Now.Ticks });

            Assert.AreNotEqual(0, movieData.ID);
        }

        [TestMethod]
        public void PutMovieServiceTest()
        {
            Service.MovieService movieService = new Service.MovieService(new MovieDataProvider());
            var movieData = movieService.Post(new Dto.MovieDto() { Title = "Test Title", Cast = new[] { "Test Cast1", "Test Cast 2" }, Classification = "Test Classification", Genre = "Test Genre", Rating = 5, ReleaseDate = (int)DateTime.Now.Ticks });

            Assert.AreNotEqual(0, movieData.ID);

            var searchQuery = new Dto.MovieQuery();
            searchQuery.SearchCriteria.ID = movieData.ID;
            var searchResult = movieService.Get(searchQuery);

            Assert.IsNotNull(searchResult);
            Assert.AreNotEqual(0, searchResult.records);

            movieData.Title = "Test Title Changed";

            var result = movieService.Put(movieData.ID ?? 0, movieData);
            Assert.IsTrue(result);

            searchResult = movieService.Get(searchQuery);
            Assert.IsNotNull(searchResult);
            Assert.AreNotEqual(0, searchResult.records);

            List<MovieDto> data = new List<MovieDto>(searchResult.rows);
            Assert.AreEqual("Test Title Changed", data[0].Title, true);


        }
    }
}