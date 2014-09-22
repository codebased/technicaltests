//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Core.Configuration
{
    using System.Web.Http;

    /// <summary>
    /// Static class for WebApiConfig functions.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register WebApi to the Routes.
        /// </summary>
        /// <param name="config">Http Configuratoin</param>
        public static void Register(HttpConfiguration config)
        {
            // Map http routing to the service.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Defaulting to use JSON data type in return.
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
