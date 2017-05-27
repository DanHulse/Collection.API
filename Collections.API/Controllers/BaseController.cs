using System.Web.Http;
using Collections.API.Infrastructure.Interfaces;

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