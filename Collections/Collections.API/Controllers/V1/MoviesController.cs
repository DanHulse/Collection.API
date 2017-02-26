﻿using System;
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
using Collections.API.Mapper.Interfaces;
using Collections.API.Models.Interfaces;

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
        /// The data service
        /// </summary>
        private readonly IDataService dataService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="dataService">The data service</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="logger">The logger.</param>
        public MoviesController(IDataService dataService, IMapper mapper, ILogger logger)
        {
            this.dataService = dataService;
            this.mapper = mapper;
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
                var result = await this.dataService.GetAsync<IMovieModel>();

                if (result.Any())
                {
                    var mappedResults = this.mapper.Map<IEnumerable<MovieViewModel>>(result);

                    return this.Ok(mappedResults);
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
                var result = await this.dataService.GetByIdAsync<IMovieModel>(id);

                if (result != null)
                {
                    var mappedResult = this.mapper.Map<MovieDetailViewModel>(result);

                    return this.Ok(mappedResult);
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
                var result = await this.dataService.PostAsync<IMovieModel, MovieModel>(model);

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
                var result = await this.dataService.PatchAsync<IMovieModel, MovieModel>(id, model);

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
                var result = await this.dataService.DeleteAsync<IMovieModel>(ids);

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