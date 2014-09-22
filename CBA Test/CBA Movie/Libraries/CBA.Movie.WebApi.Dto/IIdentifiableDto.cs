//-----------------------------------------------------------------------
// <copyright file="IIdentifiableDto.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Dto
{
    /// <summary>
    /// This Interface will be implemented by all identifiable DTO - objects.
    /// </summary>
    public interface IIdentifiableDto
    {
        /// <summary>
        /// Gets or sets the identity of a DTO object.
        /// </summary>
        int? ID
        {
            get;
            set;
        }
    }
}
