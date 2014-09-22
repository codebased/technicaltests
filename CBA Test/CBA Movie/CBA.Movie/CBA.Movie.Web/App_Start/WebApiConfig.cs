//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.Web
{
    using System.Web.Http;

    /// <summary>
    /// Web Api configurations.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// regiRegister web api interface.
        /// </summary>
        /// <param name="config">Application Global Configuration</param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
