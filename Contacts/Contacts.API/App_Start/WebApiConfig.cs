using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Contacts.API.Filters;
using Contacts.API.Infrastructure;
using Contacts.Common.ErrorHandling;
using Contacts.Common.IoC;
using Contacts.Common.Logging;

namespace Contacts.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.EnableCors();

            // Enable CORS for all origins, all headers and all methods.
            // Tweak this to meet your requirements
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            GlobalConfiguration.Configuration.EnsureInitialized();

            // Configure filters
            config.Filters.Add(new ValidateViewModelFilterAttribute());

            // Replace ContentNegotiator service to return only JSON response for all responses no matter what content type is requested
            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof (IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            config.Services.Replace(typeof (IExceptionHandler),
                                    new GlobalExceptionHandler());

            // Add services
            config.Services.Add(typeof (IExceptionLogger),
                                new MyExceptionLogger(WebContainerManager.Get<ILogManager>()));
        }
    }
}