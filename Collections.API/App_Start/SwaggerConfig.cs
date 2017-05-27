using System.Web;
using System.Web.Http;
using Swashbuckle.Application;

namespace Collection
{
    /// <summary>
    /// The swagger configuration
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Collections API")
                    .Description("An API for CRUD requests to a Collections Database");
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
            })
                .EnableSwaggerUi(c => { });
        }

        /// <summary>
        /// Gets the XML comments path.
        /// </summary>
        /// <returns>Path to Xml document</returns>
        protected static string GetXmlCommentsPath()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/Collections.API.xml");

            return path;
        }
    }
}
