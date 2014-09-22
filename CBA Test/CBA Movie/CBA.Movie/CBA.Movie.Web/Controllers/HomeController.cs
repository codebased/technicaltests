//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        /// <summary>
        /// Get the index view
        /// </summary>
        /// <returns>Movie List View</returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}