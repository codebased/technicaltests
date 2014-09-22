//-----------------------------------------------------------------------
// <copyright file="ServiceEvent.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the service vent.
    /// </summary>
    public class ServiceEvent
    {
        /// <summary>
        ///  Initializes a new instance of the ServiceEvent class.
        /// </summary>
        public ServiceEvent()
        {
            this.Updates = new List<ServiceActivity>();
        }

        /// <summary>
        /// Gets or sets the service event id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the service description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the service title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the service event start time.
        /// </summary>
        public DateTime BeginAt { get; set; }

        /// <summary>
        /// Gets or sets the service event end time.
        /// </summary>
        public DateTime ResolvedAt { get; set; }

        /// <summary>
        /// Gets or sets the service status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the list of updates against service event.
        /// </summary>
        public List<ServiceActivity> Updates
        { get; set; }
    }
}
