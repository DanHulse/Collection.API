using Collections.API.Infrastructure.Interfaces;
using System.Web.Http;

namespace Collections.API.Controllers
{
    /// <summary>
    /// The Base controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ApiController
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public virtual ILogger Logger { get; set; }
    }
}