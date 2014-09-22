//-----------------------------------------------------------------------
// <copyright file="MovieController.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Core.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using CBA.Movie.WebApi.Core.Service;
    using CBA.Movie.WebApi.Dto;

    /// <summary>
    /// Movie Controller defines the AP methods that are available to the external staff.
    /// </summary>
    public class MovieController : ApiController
    {
        private IMovieService service;

        /// <summary>
        /// Initialises a new instance of MovieController.
        /// </summary>
        /// <param name="service"></param>
        public MovieController(IMovieService service)
        {
           this.service = service;
        }

        /// <summary>
        ///  
        /// This method will accomplish 3 tasks.
        /// 1) Fetch movies from the third party datasource. 
        /// 2) Return movies in a sorted order by any of the movie attributes. (Except for the field “Cast”)
        /// 3) Search across all fields within the movie.
        ///  
        /// </summary>
        /// <param name="search">Movie search criteria</param>
        /// <returns>Http response message for WEBAPI Call</returns>
        public HttpResponseMessage Get([FromUri]  MovieQuery search)
        {
            try
            {
                var listPage = this.service.Get(search);

                if (listPage.rows == null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.NotFound, "Movie not found");
                    throw new HttpResponseException(response);
                }

                return Request.CreateResponse<ListPageDto<MovieDto>>(
                                    HttpStatusCode.OK, listPage);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unexpected exception occured."));
            }
        }
         
        /// <summary>
        /// Insert a new movie
        /// 
        /// Task: 4) Insert new movie
        /// </summary>
        /// <param name="movieDto">Movie data transaction object</param> 
        /// <returns>Insert response in http format.</returns>
        public HttpResponseMessage Post([FromBody] Dto.MovieDto movieDto)
        {
            try
            {
                movieDto = this.service.Post(movieDto);

                var response = Request.CreateResponse<Dto.MovieDto>(HttpStatusCode.Created, movieDto);

                string uri = Url.Link("DefaultApi", new { id = movieDto.ID });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unexpected exception occured."));
            }
        }

        /// <summary>
        /// Update a movie
        /// 
        /// Task: 5) Update existing movie.
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <param name="movieDto">Movie data transaction object</param> 
        public void Put(int id, [FromBody] Dto.MovieDto movieDto)
        {
            try
            {
                this.service.Put(id, movieDto);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unexpected exception occured."));
            }
        }
    }
}
