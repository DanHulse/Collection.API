using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Collections.API.MIddleware
{
    /// <summary>
    /// Middleware for handling errors and exceptions in the API
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        /// <summary>
        /// The next request
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next request.</param>
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the middleware for the context.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <returns>An instenace of <see cref="Task"/>.</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles exceptions thrown when processing requests.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="exception">The exception thrown when processing the request.</param>
        /// <returns>An instance of <see cref="Task"/>.</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception is KeyNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (exception is ArgumentNullException)
            {
                code = HttpStatusCode.BadRequest;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
