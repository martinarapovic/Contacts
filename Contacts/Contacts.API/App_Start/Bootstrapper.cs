using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Contacts.API.Mappings;
using Contacts.Common.Logging;
using Contacts.Data.Infrastructure;
using Contacts.Data.Repositories;
using Contacts.Services;

namespace Contacts.API.App_Start
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureLog4Net();
            ConfigureAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void ConfigureLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();
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
            containerBuilder.RegisterType<EmailAddressesRepository>().As<IEmailAddressRepository>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<LabelRepository>().As<ILabelRepository>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<PhoneNumberRepository>().As<IPhoneNumberRepository>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<TagRepository>().As<ITagRepository>().AsImplementedInterfaces().InstancePerRequest();

            // Configure services
            containerBuilder.RegisterType<ContactService>().As<IContactService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<EmailAddressService>().As<IEmailAddressService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<LabelService>().As<ILabelService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<PhoneNumberService>().As<IPhoneNumberService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<TagService>().As<ITagService>().AsImplementedInterfaces().InstancePerRequest();

            containerBuilder.RegisterType<LogManagerAdapter>().As<ILogManager>().AsImplementedInterfaces().InstancePerLifetimeScope();

            // Register all API controllers from current project 
            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            IContainer container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}