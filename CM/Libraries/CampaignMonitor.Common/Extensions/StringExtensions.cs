//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.Common.Extensions
{
    /// <summary>
    /// Extend string type with custom build extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Check if the string variable is empty or null.
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>return true if the object is either null or empty</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null  || value.Length == 0;
        }
    }
}