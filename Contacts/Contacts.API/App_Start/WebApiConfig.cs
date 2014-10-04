using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Contacts.API.Infrastructure;

namespace Contacts.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var corsPolicy = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(corsPolicy);
            config.EnableCors();

            // Enable cors for all origins, all headers and all methods.
            // Tweak this to meet your requirements
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Replace ContentNegotiator service to return only JSON response for all responses no matter what content type is requested
            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

        }
    }
}
