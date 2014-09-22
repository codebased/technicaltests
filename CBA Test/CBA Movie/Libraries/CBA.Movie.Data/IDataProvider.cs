//-----------------------------------------------------------------------
// <copyright file="IDataProvider.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.Data.Interface
{
    using System;
    using System.Collections.Generic;
    using MoviesLibrary;

    /// <summary>
    /// Data Provider interface will be implemented by different Movie Data provider. 
    /// In our case it will be MovieAPI.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Create new movie record.
        /// </summary>
        /// <param name="movie">movie data </param>
        /// <returns>identification number</returns>
        int CreateMovie(MovieData movie);

        /// <summary>
        /// Get movie by ID.
        /// </summary>
        /// <param name="movieID">Movie data identification number</param>
        /// <returns>Movie Data</returns>
        MovieData GetMovie(int movieID);

        /// <summary>
        /// Get movies
        /// </summary>
        /// <returns>Collection of movie data.</returns>
        List<MovieData> GetMovies();

        /// <summary>
        /// Update existing movie data.
        /// </summary>
        /// <param name="movie">movie data</param>
        /// <returns>on success return true.</returns>
        bool UpdateMovie(MoviesLibrary.MovieData movie);
    }
}
