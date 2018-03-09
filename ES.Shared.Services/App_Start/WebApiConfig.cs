using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ES.Shared.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            
            // Web API routes
            if (config == null)
            {
                return;
            }

            //config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
