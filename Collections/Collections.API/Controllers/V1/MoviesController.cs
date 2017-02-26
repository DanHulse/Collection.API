using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Collections.API.Enumerations;
using Collections.API.Infrastructure.Interfaces;
using Collections.API.Models;
using Collections.API.Services.Interfaces;
using Collections.API.ViewModels;

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
        /// Retrieve all movies
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of all movies</returns>
        [HttpGet]
        [Route("", Name = "GetMovies")]
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

        /// <summary>
        /// Retrieve requested movie
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of requested movie</returns>
        [HttpGet]
        [Route("{id}", Name = "GetMovieById")]
        [ResponseType(typeof(MovieDetailViewModel))]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri]string id)
        {
            try
            {
                var result = await this.moviesService.GetByIdAsync(id);

                if (result != null)
                {
                    return this.Ok(result);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to retrive movie with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Insert new movies to DB
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPost]
        [Route("", Name = "PostMovies")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PostAsync([FromBody]IEnumerable<MovieModel> model)
        {
            try
            {
                var result = await this.moviesService.PostAsync(model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to post the movies");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates specified movie
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPatch]
        [Route("{id}", Name = "PatchMovie")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PatchAsync([FromUri]string id, [FromBody]MovieModel model)
        {
            try
            {
                var result = await this.moviesService.PatchAsync(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to patch movie with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the movies asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers of the movies to delete.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpDelete]
        [Route("", Name = "DeleteMovies")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        {
            try
            {
                var result = await this.moviesService.DeleteAsync(ids);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to delete movies");

                return this.InternalServerError(ex);
            }
        }
    }
}