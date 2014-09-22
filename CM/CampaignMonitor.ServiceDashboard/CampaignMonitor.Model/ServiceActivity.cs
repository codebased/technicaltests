//-----------------------------------------------------------------------
// <copyright file="ServiceActivity.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.Model
{
    using System;

    /// <summary>
    /// Defines the service activities that composite with Service Event.
    /// </summary>
    public class ServiceActivity
    {
        /// <summary>
        /// Gets or sets the service activity id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the user who has done the activity.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Avatar URL.
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the actioned date and time.
        /// </summary>
        public DateTime ActionedOn { get; set; }

        /// <summary>
        /// Gets or sets the comment against Activity.
        /// </summary>
        public string Update { get; set; }

    }
}
