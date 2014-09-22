//-----------------------------------------------------------------------
// <copyright file="MovieDto.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Dto
{
    /// <summary>
    /// Base class for movie data. 
    /// </summary>
    public class MovieDto : IIdentifiableDto
    {
        /// <summary>
        /// Gets or sets movie Classification
        /// </summary>
        public string Classification
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets movie Genre
        /// </summary>
        public string Genre
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets movie rating
        /// </summary>
        public int? Rating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets movie release date.
        /// </summary>
        public int? ReleaseDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets movie title.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int? ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets movie cast names.
        /// </summary>
        public string[] Cast
        {
            get;
            set;
        }
    }
}
