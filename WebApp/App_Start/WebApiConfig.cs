using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.WebHost;
using WebDemo;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var httpControllerRouteHandler = typeof(HttpControllerRouteHandler).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            if (httpControllerRouteHandler != null)
            {
                httpControllerRouteHandler.SetValue(null, new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));
            }
            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
