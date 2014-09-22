// <copyright file="IMovieService.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Core.Service
{
    using System.ServiceModel;
    using CBA.Movie.WebApi.Dto;
    using CBA.Movie.WebApi.Core.Service;

    /// <summary>
    /// Service Contract - Movie Interface.
    /// </summary>
    [ServiceContract]
    public interface IMovieService
    {
        /// <summary>
        /// Get the movie database.
        /// </summary>
        /// <param name="search">search criteria object</param>
        /// <returns>Page List</returns>
        [OperationContract]
        ListPageDto<MovieDto> Get(MovieQuery search);

        /// <summary>
        /// Insert a new movie
        /// 
        /// Task: 4) Insert new movie
        /// </summary>
        /// <param name="movieDto">Movie data transaction object</param> 
        /// <returns>Insert response in http format.</returns>
        [OperationContract]
        MovieDto Post(MovieDto movieDto);

        /// <summary>
        /// Update a movie
        /// 
        /// Task: 5) Update existing movie.
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <param name="movieDto">Movie data transaction object</param> 
        [OperationContract]
        bool Put(int id, MovieDto movieDto);
    }
}
