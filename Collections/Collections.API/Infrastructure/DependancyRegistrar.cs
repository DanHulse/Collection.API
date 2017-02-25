using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Collections.API.Infrastructure.Interfaces;
using Collections.API.Services.Interfaces;
using Collections.API.Repositories.Interfaces;
using Collections.API.Mapper.Interfaces;
using Collections.API.Factories.Interfaces;
using Collections.API.Models.Interfaces.Movies;

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

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof(IService).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof(IRepository).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof(IMapper).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(t => typeof(IMongoFactory<IMovieModel>).IsAssignableFrom(t))
            //    .AsImplementedInterfaces();

            //builder.Register(c => c.Resolve<IAuthenticationFactory>().Connect()).As<IOrganizationService>().SingleInstance();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}