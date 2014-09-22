//-----------------------------------------------------------------------
// <copyright file="DashboardController.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.ServiceDashboard.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Defines Dashboard Controller view user interface.
    /// </summary>
    public class DashboardController : Controller
    {

        /// <summary>
        /// Get Index.
        /// </summary>
        /// <returns>View Index</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Contact.
        /// </summary>
        /// <returns>View Contact</returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// Get Main.
        /// </summary>
        /// <returns>View Main</returns>
        public ActionResult Main()
        {
            return View();
        }

        /// <summary>
        /// Get Service .
        /// </summary>
        /// <returns>View Service</returns>
        public ActionResult Service()
        {
            return View();
        }

        /// <summary>
        /// Get JavaScriptTest .
        /// </summary>
        /// <returns>View JavaScriptTest</returns>
        public ActionResult JavaScriptTest()
        {
            return View();
        }

        /// <summary>
        /// Get CSharpTest .
        /// </summary>
        /// <returns>View JavaScriptTest</returns>
        public ActionResult CSharpTest()
        {
            return View();
        }
    }
}
