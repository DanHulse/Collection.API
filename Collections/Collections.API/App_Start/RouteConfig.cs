using System.Web.Http;
using System.Web.Routing;
using Swashbuckle.Application;

namespace Collections.API.App_Start
{
    /// <summary>
    /// The Route config.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: string.Empty,
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger"));
        }
    }
}