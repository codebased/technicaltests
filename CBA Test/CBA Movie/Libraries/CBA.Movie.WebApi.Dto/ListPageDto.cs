//-----------------------------------------------------------------------
// <copyright file="ListPageDto.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Dto
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the list page that can be used anywhere else.
    /// </summary>
    /// <typeparam name="T">List page item type.</typeparam>
    public class ListPageDto<T>
    {
        /// <summary>
        ///  Initializes a new instance of the ListPageDto class.
        /// </summary>
        public ListPageDto()
        {
            this.total = this.page = this.records = 0;
        }

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        public IEnumerable<T> rows { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Gets or sets the total number of records.
        /// </summary>
        public int records { get; set; }
   }
}
