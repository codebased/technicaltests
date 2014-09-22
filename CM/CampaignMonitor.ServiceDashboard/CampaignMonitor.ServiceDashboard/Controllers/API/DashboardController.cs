//-----------------------------------------------------------------------
// <copyright file="DashboardController.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.ServiceDashboard.Controllers.API
{
    using CampaignMonitor.Model;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// Defines the API calls for the dashboard interface.
    /// </summary>
    public class DashboardController : ApiController
    {
        /// <summary>
        /// Get the Dashbaord status.
        /// </summary>
        /// <returns></returns>
        public List<ServiceEvent> Get()
        {
            ServiceEvent event1 = new ServiceEvent()
            {
                ID = 3,
                Description = "We forgot to turn on the SimCity servers. It will take us a couple of days to find the on switch. We don't care",
                Title = "No one can play our game!",
                BeginAt = DateTime.Now.AddHours(-1),
                ResolvedAt = DateTime.Now,
                Status = "Resolved"
            };

            ServiceEvent event2 = new ServiceEvent()
            {
                ID = 2,
                Description = "Looks like a large lizard is bringing down your buildings.",
                Title = @"It's GODZILLA!!!",
                BeginAt = DateTime.Now.AddHours(-1),
                ResolvedAt = DateTime.Now,
                Status = "Resolved",
                Updates = new List<ServiceActivity>()
            };


            event1.Updates = new List<ServiceActivity>();

            event1.Updates.Add(new ServiceActivity()
            {
                ID = 8,
                UserName = "Matthew",
                Avatar = "http://status.campaignmonitor.com/img/staff/mathewp.jpg",
                ActionedOn = DateTime.Now,
                Update = "We plugged in some laptops, that should do it..."
            });

            event1.Updates.Add(new ServiceActivity()
            {
                ID = 7,
                UserName = "Matthew",
                Avatar = "http://status.campaignmonitor.com/img/staff/mathewp.jpg",
                ActionedOn = DateTime.Now,
                Update = "Dispite the huge amount of pre-release publicity and pre-orders, we didn't expect any one to try and play on launch day. How could we, it's not like we're a multinational video game company or anything"
            });

            event2.Updates = new List<ServiceActivity>();
            event2.Updates.Add(new ServiceActivity()
            {
                ID = 6,
                UserName = "JD",
                Avatar = "http://status.campaignmonitor.com/img/staff/jasond.jpg",
                ActionedOn = DateTime.Now,
                Update = "He's down, looks like the airforce has got him. Bring out yer dead."
            });

            event2.Updates.Add(new ServiceActivity()
            {
                ID = 5,
                UserName = "JD",
                Avatar = "http://status.campaignmonitor.com/img/staff/jasond.jpg",
                ActionedOn = DateTime.Now,
                Update = "The lizard is heading towards the river, we're calling in some A10's so we should have this stuff sorted soonish."
            });


            event2.Updates.Add(new ServiceActivity()
            {
                ID = 3,
                UserName = "JD",
                Avatar = "http://status.campaignmonitor.com/img/staff/jasond.jpg",
                ActionedOn = DateTime.Now,
                Update = "Whoa, where did this thing come from. Old fella is heading up towards the power stations, good thing we put the sewage there too."
            });


            List<ServiceEvent> events = new List<ServiceEvent>();

            events.Add(event1);
            events.Add(event2);

            return events;
        }
    }
}
