//-----------------------------------------------------------------------
// <copyright file="IntegerExtensions.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.Common.Extensions
{
    /// <summary>
    /// Extend integer type with custom build extensions.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Check if the number is factorable or not.
        /// </summary>
        /// <param name="value">the integer factor number.</param>
        /// <returns>return true if the number is greater than zero.</returns>
        public static bool IsFactorable(this int value)
        {
            return value > 0;
        }
    }
}
