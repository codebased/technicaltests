//-----------------------------------------------------------------------
// <copyright file="Page.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
 
namespace CBA.Movie.WebApi.Dto
{
    /// <summary>
    /// Defines the page attributes.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Initializes a new instance of the Page class.
        /// </summary>
        public Page()
        {
            this.PageNumber = 1;
        }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int PageNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }
    }
}
