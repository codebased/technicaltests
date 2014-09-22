//-----------------------------------------------------------------------
// <copyright file="MovieSortOptions.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CBA.Movie.WebApi.Dto
{
    /// <summary>
    /// Defines Movie sort options
    /// </summary>
    public enum MovieSortOptions
    {
        /// <summary>
        /// Defines ID
        /// </summary>
        ID,

        /// <summary>
        /// Defines movie classification
        /// </summary>
        Classification,

        /// <summary>
        /// Defines movie title.
        /// </summary>
        Title,

        /// <summary>
        /// Defines movie Genre 
        /// </summary>
        Genre,

        /// <summary>
        /// Defines movie Rating
        /// </summary>
        Rating,

        /// <summary>
        /// Defines movie release date.
        /// </summary>
        ReleaseDate
    }
}
