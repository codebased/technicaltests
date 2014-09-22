//-----------------------------------------------------------------------
// <copyright file="MovieAPIDataProvider.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using CBA.Movie.Data.Interface;
    using MoviesLibrary;

    /// <summary>
    /// This class is responsible to communicate with the API and Provide data to the Business Layer.
    /// </summary>
    public class MovieDataProvider : IDataProvider
    {
        /// <summary>
        /// Cache Key.
        /// </summary>
        private readonly string CACHEKEY = "CBA.MOVIE.LIST";

        /// <summary>
        /// When retreiving big data it is required to lock current Thread.
        /// </summary>
        private readonly object thisLock = new object();

        /// <summary>
        /// Gets or sets the Data source.
        /// </summary>
        private static MovieDataSource dSource
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the memory cache.
        /// </summary>
        private static MemoryCacheWrapper<List<MovieData>> cache
        {
            get;
            set;
        }

        /// <summary>
        /// Sets static value.
        /// </summary>
        static MovieDataProvider()
        {
            MovieDataProvider.dSource = new MovieDataSource();
            MovieDataProvider.cache = new MemoryCacheWrapper<List<MovieData>>("MovieData");
        }


        /// <summary>
        /// Create new movie record.
        /// </summary>
        /// <param name="movie">movie data </param>
        /// <returns>identification number</returns>
        public int CreateMovie(MovieData movie)
        {
            int id = MovieDataProvider.dSource.Create(movie);
            MovieDataProvider.cache.Remove(this.CACHEKEY);

            return id;
        }

        /// <summary>
        /// Update existing movie data.
        /// </summary>
        /// <param name="movie">movie data</param>
        /// <returns>on success return true.</returns>
        public bool UpdateMovie(MovieData movie)
        {
            MovieDataProvider.dSource.Update(movie);
            MovieDataProvider.cache.Remove(this.CACHEKEY);

            return true;
        }

        /// <summary>
        /// Get all movies from the MovieStore Api and store into the cache for next one day.
        /// </summary>
        /// <returns></returns>
        public List<MovieData> GetMovies()
        {
            List<MovieData> movies = null;

            lock (this.thisLock)
            {
                // check if we already have a data in the cache.
                bool dataAvailable = cache.TryGetValue(this.CACHEKEY, out movies);

                if (dataAvailable == false)
                {
                    movies = dSource.GetAllData();
                    cache.AddOrUpdate(CACHEKEY, movies);
                }
            }

            return movies;
        }

        /// <summary>
        /// Get movie by ID.
        /// </summary>
        /// <param name="movieID">Movie data identification number</param>
        /// <returns>Movie Data</returns>
        public MovieData GetMovie(int ID)
        {
            // could be done through linq as well. 
            return this.GetMovies().SingleOrDefault(x => x.MovieId.Equals(ID));
        }
    }
}