//-----------------------------------------------------------------------
// <copyright file="MovieService.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Core.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using AutoMapper;
    using CBA.Movie.Data.Interface;
    using CBA.Movie.WebApi.Dto;

    /// <summary>
    /// Main class that is responsible to get data from Movie API and returns data back.
    /// </summary>
    [AspNetCompatibilityRequirements(
       RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MovieService : IMovieService
    {
        /// <summary>
        /// 
        /// </summary>
        private IDataProvider dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataProvider"></param>
        public MovieService(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// Get the movie database.
        /// </summary>
        /// <param name="search">search criteria object</param>
        /// <returns>Page List</returns>
        public ListPageDto<MovieDto> Get(MovieQuery search)
        {
            search = search ?? new MovieQuery();

            var movies = this.dataProvider.GetMovies().Select(m => Mapper.Map<MoviesLibrary.MovieData, Dto.MovieDto>(m)).ToList();

            if (search.SearchCriteria != null)
            {
                movies = ApplyFilter(movies, search.SearchCriteria);
            }

            if (search.SortField != null)
            {
                movies = ApplySort(movies, search.SortField);
            }

            var listPage = ApplyPaging(movies, search.Paging);

            return listPage;
        }

        /// <summary>
        /// Insert a new movie
        /// 
        /// Task: 4) Insert new movie
        /// </summary>
        /// <param name="movieDto">Movie data transaction object</param> 
        /// <returns>Insert response in http format.</returns>
        public Dto.MovieDto Post(Dto.MovieDto movieDto)
        {
            var movieData = Mapper.Map<Dto.MovieDto, MoviesLibrary.MovieData>(movieDto);

            movieDto.ID = this.dataProvider.CreateMovie(movieData);

            return movieDto; ;
        }

        /// <summary>
        /// Update a movie
        /// 
        /// Task: 5) Update existing movie.
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <param name="movieDto">Movie data transaction object</param> 
        public bool Put(int ID, MovieDto movieDto)
        {
            var movieData = Mapper.Map<Dto.MovieDto, MoviesLibrary.MovieData>(movieDto);
            movieData.MovieId = ID;

            return this.dataProvider.UpdateMovie(movieData);
        }

        /// <summary>
        /// Apply paging on movie data.
        /// This can be made generic through template features. However, for now I will leave it as is.
        /// </summary>
        /// <param name="movies">movie records</param>
        /// <param name="page">page number</param>
        /// <returns>List page</returns>
        private ListPageDto<MovieDto> ApplyPaging(IEnumerable<MovieDto> movies, Page page)
        {
            var result = new ListPageDto<MovieDto>
            {
                total = 0,
                page = 0,
                records = 0,
                rows = null
            };

            if (movies != null && movies.Count() > 0)
            {
                var pageIndex = Convert.ToInt32(page.PageNumber) - 1;
                var totalRecords = movies.Count();

                page.PageSize = page.PageSize == 0 ? totalRecords : page.PageSize;

                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)page.PageSize);
                movies = movies.Skip(pageIndex * page.PageSize).Take(page.PageSize);

                result.total = totalPages;
                result.page = page.PageNumber;
                result.records = totalRecords;
                result.rows = movies;
            }

            return result;
        }

        /// <summary>
        /// Apply sorting on movie data.
        /// This canbe made generic through template features. however, for now I will leave it as is.
        /// </summary>
        /// <param name="movies">movie records</param>
        /// <param name="sortField">sort field - at present it is accepting only one sort field. However, this can be ehanced to accept multiple sort fields.</param>
        /// <returns>movie list</returns>
        private List<MovieDto> ApplySort(IEnumerable<MovieDto> movies, MovieSort sortField)
        {
            if (movies != null && movies.Count() > 0)
            {
                PropertyInfo property = typeof(MovieDto).GetProperty(sortField.SortBy.ToString());

                if (property == null)
                {
                    throw new ArgumentException("Invalid sortBy argument provided");
                }

                movies = sortField.Asc ? movies.OrderBy(x => property.GetValue(x, null)) : movies.OrderByDescending(x => property.GetValue(x, null));

                return movies.ToList<MovieDto>();
            }

            return null;
        }

        /// <summary>
        /// Apply filter on movie data.
        /// This can be made generic through template features. however, for now I will leave it as is.
        /// </summary>
        /// <param name="movies">movie records</param>
        /// <param name="searchCriteria">search field - at present it is accepting only one sort field. However, this can be ehanced to accept multiple sort fields.</param>
        private List<MovieDto> ApplyFilter(IEnumerable<MovieDto> movies, MovieDto searchCriteria)
        {

            if (searchCriteria.Cast != null && searchCriteria.Cast.Length > 0)
            {
                var castString = string.Join("", searchCriteria.Cast);
                if (!String.IsNullOrEmpty(castString))
                {
                    movies = movies.Where(m => m.Cast.Any(c => c.ToLower().Contains(castString)));

                }
            }
            if (!String.IsNullOrEmpty(searchCriteria.Classification))
            {
                movies = movies.Where(m => m.Classification.ToLower().Contains(searchCriteria.Classification.ToLower()));
            }
            if (!String.IsNullOrEmpty(searchCriteria.Genre))
            {
                movies = movies.Where(m => m.Genre.ToLower().Contains(searchCriteria.Genre.ToLower()));
            }
            if (!String.IsNullOrEmpty(searchCriteria.Title))
            {
                movies = movies.Where(m => m.Title.ToLower().Contains(searchCriteria.Title.ToLower()));
            }
            if (searchCriteria.ID.HasValue)
            {
                movies = movies.Where(m => m.ID.Equals(searchCriteria.ID));
            }
            if (searchCriteria.Rating.HasValue)
            {
                movies = movies.Where(m => m.Rating.Equals(searchCriteria.Rating));
            }
            if (searchCriteria.ReleaseDate.HasValue)
            {
                movies = movies.Where(m => m.ReleaseDate.Equals(searchCriteria.ReleaseDate));
            }

            return movies.ToList<MovieDto>();
        }
    }
}