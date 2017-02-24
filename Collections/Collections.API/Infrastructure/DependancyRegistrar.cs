using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Collections.API.Infrastructure.Interfaces;

namespace Collections.API.Infrastructure
{
    /// <summary>
    /// The Dependency registrar used for setting up DI container.
    /// </summary>
    public static class DependencyRegistrar
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterType<Logger>().As<ILogger>().InstancePerDependency();
            log4net.Config.XmlConfigurator.Configure();

            builder.RegisterApiControllers(assembly).PropertiesAutowired();
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}