using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Collections.API.Models;
using Collections.API.Models.Interfaces;
using Collections.API.Services.Interfaces;
using Collections.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Collections.API.Controllers.V1
{
    /// <summary>
    /// Movies controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.V1.CollectionsController{MovieModel, IMovieModel, MovieViewModel, MovieDetailViewModel}" />
    public class MoviesController : CollectionsController<MovieModel, IMovieModel, MovieViewModel, MovieDetailViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="collectionService">The collection service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public MoviesController(ICollectionService collectionService, IMapper mapper, ILogger<MoviesController> logger)
            : base(collectionService, mapper, logger) { }

        /// <summary>
        /// Retrieve all data records of the data type specified
        /// </summary>
        /// <returns><see cref="IActionResult"/>of all records</returns>
        [HttpGet]
        [Route("")]
        [Produces(typeof(IEnumerable<MovieViewModel>))]
        public override async Task<IActionResult> GetAsync() { return await base.GetAsync(); }

        /// <summary>
        /// Retrieve requested record
        /// </summary>
        /// <returns><see cref="IActionResult"/>of requested record</returns>
        [HttpGet]
        [Route("{id}")]
        [Produces(typeof(MovieDetailViewModel))]
        public override async Task<IActionResult> GetByIdAsync([FromRoute]string id) { return await base.GetByIdAsync(id); }

        /// <summary>
        /// Performs an advanced search function on the provided model
        /// </summary>
        /// <param name="model">The model type to be searched.</param>
        /// <returns><see cref="IActionResult"/>of search results</returns>
        [HttpPost]
        [Route("search")]
        [Produces(typeof(IEnumerable<MovieViewModel>))]
        public override async Task<IActionResult> PostSearchAsync([FromBody]MovieModel model) { return await base.PostSearchAsync(model); }

        /// <summary>
        /// Insert new records to DB of specified type
        /// </summary>
        /// <param name="model">The record to be posted</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpPost]
        [Route("")]
        [Produces(typeof(IActionResult))]
        public override async Task<IActionResult> PostAsync([FromBody]IEnumerable<MovieModel> model) { return await base.PostAsync(model); }

        /// <summary>
        /// Updates specified record
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpPatch]
        [Route("{id}")]
        [Produces(typeof(IActionResult))]
        public override async Task<IActionResult> PatchAsync([FromRoute]string id, [FromBody]MovieModel model) { return await base.PatchAsync(id, model); }

        /// <summary>
        /// Replaces the specified record with the new model
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpPut]
        [Route("{id}")]
        [Produces(typeof(IActionResult))]
        public override async Task<IActionResult> PutAsync([FromRoute]string id, [FromBody]MovieModel model) { return await base.PutAsync(id, model); }

        /// <summary>
        /// Deletes the record of the specified type asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the record to delete.</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpDelete]
        [Route("")]
        [Produces(typeof(IActionResult))]
        public override async Task<IActionResult> DeleteAsync([FromRoute]string id) { return await base.DeleteAsync(id); }
    }
}
