using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Contacts.API.Mappings;
using Contacts.Data.Infrastructure;
using Contacts.Data.Repositories;
using Contacts.Services;

namespace Contacts.API.App_Start
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void ConfigureAutofacContainer()
        {

            var webApiContainerBuilder = new ContainerBuilder();
            ConfigureWebApiContainer(webApiContainerBuilder);
        }

        private static void ConfigureWebApiContainer(ContainerBuilder containerBuilder)
        {
            // Configure db factory and UnitOfwork
            containerBuilder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerRequest();

            // Configure repositories
            containerBuilder.RegisterType<ContactRepository>().As<IContactRepository>().AsImplementedInterfaces().InstancePerRequest();

            // Configure services
            containerBuilder.RegisterType<ContactService>().As<IContactService>().AsImplementedInterfaces().InstancePerRequest();

            // Register all API controllers from current project 
            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            IContainer container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}