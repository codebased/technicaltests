


namespace CBA.Movie.WebHost
{
    using CBA.Movie.WebApi.Core.Configuration;
    using System;
    using System.Web.Http;
    //using CBA.Movie.WebHost.App_Start;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            DtoMapperConfig.CreateMaps();
        }

    }
}