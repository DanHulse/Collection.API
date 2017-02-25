using Collections.API.Enumerations;
using Collections.API.Infrastructure.Interfaces;
using Collections.API.Services.Interfaces;
using Collections.API.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Collections.API.Controllers.V1
{
    /// <summary>
    /// Movies collection controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.BaseController" />
    [RoutePrefix("api/v1/Movies")]
    public class MoviesController : BaseController
    {
        /// <summary>
        /// The movies service
        /// </summary>
        private readonly IMoviesService moviesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="moviesService">The movies service</param>
        /// <param name="logger">The logger.</param>
        public MoviesController(IMoviesService moviesService, ILogger logger)
        {
            this.moviesService = moviesService;
            this.Logger = logger;
        }

        /// <summary>
        /// Gets all movies
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of all movies</returns>
        [HttpGet]
        [Route("", Name = "Get")]
        [ResponseType(typeof(IEnumerable<MovieViewModel>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var result = await this.moviesService.GetAsync();

                if (result.Any())
                {
                    return this.Ok(result);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to retrive movies");

                return this.InternalServerError(ex);
            }
        }
    }
}