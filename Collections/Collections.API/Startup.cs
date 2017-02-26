using System.Web.Http;
using System.Web.Routing;
using Collection;
using Collections.API.App_Start;
using Collections.API.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Collections.API.Startup))]

namespace Collections.API
{
    /// <summary>
    /// Startup class
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name = "app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            SwaggerConfig.Register(config);
            WebApiConfig.Register(config);
            DependencyRegistrar.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapConfig.Configure();
            BsonMapConfig.Configure();
        }
    }
}
