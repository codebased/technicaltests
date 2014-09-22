//-----------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.Common.Extension
{
    /// <summary>
    /// Defines string extension methods.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Check if the string has some value.
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>return true on nonempty string</returns>
        public static bool HasValue(this string value)
        {
            return value != null && value.Length > 0;
        }
    }
}
