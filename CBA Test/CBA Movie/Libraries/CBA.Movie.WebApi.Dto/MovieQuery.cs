//-----------------------------------------------------------------------
// <copyright file="MovieQuery.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Dto
{
    /// <summary>
    /// Defines the movie search option.
    /// </summary>
    public class MovieQuery
    {
        /// <summary>
        /// Initializes a new instance of the MovieQuery class.
        /// </summary>
        public MovieQuery()
        {
            this.SearchCriteria = new MovieDto();
            this.SortField = new MovieSort();
            this.Paging = new Page();
        }

        /// <summary>
        /// Gets or sets the search criteria
        /// </summary>
        public MovieDto SearchCriteria { get; set; }

        /// <summary>
        /// Gets or sets the sorting field.
        /// </summary>
        public MovieSort SortField { get; set; }

        /// <summary>
        /// Gets or sets the Paging information.
        /// </summary>
        public Page Paging { get; set; }
    }
}
