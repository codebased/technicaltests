//-----------------------------------------------------------------------
// <copyright file="MovieSort.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Dto
{
    /// <summary>
    /// Defines attributes for Sorting
    /// </summary>
    public class MovieSort
    {
        /// <summary>
        ///  Initializes a new instance of the MovieSort class.
        /// </summary>
        public MovieSort()
        {
            this.SortBy = MovieSortOptions.Title;
            this.Asc = true;
        }

        /// <summary>
        /// Gets or sets the sort by field option.
        /// </summary>
        public MovieSortOptions SortBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if it is ascending or descending order.
        /// </summary>
        public bool Asc { get; set; }
    }
}
