using Collection.API.Models;
using Collection.API.Services.Interfaces;
using Collection.API.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.API.Controllers.V1
{
    /// <summary>
    /// Controller for Movies collection
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class MoviesController : Controller
    {
        /// <summary>
        /// The movies service
        /// </summary>
        private readonly IMoviesService moviesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="moviesService">The movies service.</param>
        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;          
        }

        /// <summary>
        /// Get all movies asynchronously
        /// </summary>
        /// <returns><see cref="IEnumerable{IMovieViewModel}"/>of requested movies from collection</returns>
        [HttpGet("")]
        [Produces(typeof(IEnumerable<IMovieViewModel>))]
        public async Task<IActionResult> GetAsync()
        {
            var movies = await this.moviesService.GetMoviesAsync();

            if (movies != null)
            {
                return this.Ok(movies);
            }

            return this.NoContent();
        }

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IMovieDetailViewModel"/>requested movie from collection</returns>
        [HttpGet("{id}")]
        [Produces(typeof(IMovieDetailViewModel))]
        public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
        {
            var movie = await this.moviesService.GetMovieByIdAsync();

            if (movie != null)
            {
                return this.Ok(movie);
            }

            return this.NoContent();
        }

        /// <summary>
        /// Posts movie model to the server asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IActionResult"/>result of POST</returns>
        [HttpPost("")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> PostAsync([FromBody]MovieModel model)
        {
            var success = await this.moviesService.PostMovieAsync(model);

            if (success)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        /// <summary>
        /// Patches the movie asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IActionResult"/>result of PATCH</returns>
        [HttpPatch("")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> PatchAsync([FromBody]MovieModel model)
        {
            var success = await this.moviesService.PatchMovieAsync(model);

            if (success)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}
