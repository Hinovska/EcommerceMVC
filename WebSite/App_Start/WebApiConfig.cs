using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AppCore.WebSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiRest",
                routeTemplate: "api/{controller}/{codigo}",
                defaults: new { codigo = RouteParameter.Optional }
            );
        }
    }
}
