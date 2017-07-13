using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Collections.API.Controllers
{
    /// <summary>
    /// Base Controller for API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class BaseController : Controller
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        protected ILogger Logger { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        protected BaseController(ILogger logger)
        {
            this.Logger = logger;
        }

        /// <summary>
        /// Handles Internal Server Errors from the controllers.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns><see cref="ObjectResult"/>New result with exception message</returns>
        protected virtual IActionResult InternalServerError(Exception ex)
        {
            this.Logger.LogCritical(ex.Message, ex);

            return this.StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
