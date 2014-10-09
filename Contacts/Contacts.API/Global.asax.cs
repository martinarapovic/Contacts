using System.Net.Http.Formatting;
using Contacts.API.App_Start;
using Contacts.Common.IoC;
using Contacts.Data;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Contacts.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Bootstrap app
            Bootstrapper.Configure();
            
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Support only JSON responses for all requests
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
            
            // Setup db initializer
            Database.SetInitializer(new ContactsDbInitializer());

            AreaRegistration.RegisterAllAreas();
            
            // MVC configuration related
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception != null)
            {
                
            }
        }
    }
}
