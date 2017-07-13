using System;
using System.Collections.Generic;
using System.Linq;
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
    /// The Collections controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.BaseController" />
    [Route("api/v1/[controller]")]
    public class CollectionsController : BaseController
    {
        /// <summary>
        /// The collection service
        /// </summary>
        private readonly ICollectionService collectionService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionsController"/> class.
        /// </summary>
        /// <param name="collectionService">The collection service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CollectionsController(ICollectionService collectionService, IMapper mapper, ILogger logger)
            : base(logger)
        {
            this.collectionService = collectionService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieve all data records of the data type specified
        /// </summary>
        /// <returns><see cref="IActionResult"/>of all records</returns>
        [HttpGet]
        [Route("")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await this.collectionService.GetAsync<IAlbumModel, AlbumModel>();

                if (result.Any())
                {
                    var mappedResults = this.mapper.Map<IEnumerable<AlbumViewModel>>(result);

                    return this.Ok(mappedResults);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieve requested record
        /// </summary>
        /// <returns><see cref="IActionResult"/>of requested record</returns>
        [HttpGet]
        [Route("{id}")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> GetByIdAsync([FromRoute]string id)
        {
            try
            {
                var result = await this.collectionService.GetByIdAsync<IAlbumModel>(id);

                if (result != null)
                {
                    var mappedResult = this.mapper.Map<AlbumDetailViewModel>(result);

                    return this.Ok(mappedResult);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Performs an advanced search function on the provided model
        /// </summary>
        /// <param name="model">The model type to be searched.</param>
        /// <returns><see cref="IActionResult"/>of search results</returns>
        [HttpPost]
        [Route("search")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> PostSearchAsync([FromBody]AlbumModel model)
        {
            try
            {
                var result = await this.collectionService.PostSearchAsync<IAlbumModel, AlbumModel>(model);

                if (result.Any())
                {
                    var mappedResult = this.mapper.Map<IEnumerable<AlbumViewModel>>(result);

                    return this.Ok(mappedResult);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Insert new records to DB of specified type
        /// </summary>
        /// <param name="model">The record to be posted</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpPost]
        [Route("")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> PostAsync([FromBody]IEnumerable<AlbumModel> model)
        {
            try
            {
                var result = await this.collectionService.PostAsync<IAlbumModel, AlbumModel>(model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates specified record
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpPatch]
        [Route("{id}")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> PatchAsync([FromRoute]string id, [FromBody]AlbumModel model)
        {
            try
            {
                var result = await this.collectionService.PatchAsync<IAlbumModel, AlbumModel>(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Replaces the specified record with the new model
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpPut]
        [Route("{id}")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> PutAsync([FromRoute]string id, [FromBody]AlbumModel model)
        {
            try
            {
                var result = await this.collectionService.PutAsync<IAlbumModel, AlbumModel>(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the records of the specified type asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers of the records to delete.</param>
        /// <returns><see cref="IActionResult"/>OK if successful</returns>
        [HttpDelete]
        [Route("")]
        [Produces(typeof(IActionResult))]
        public async Task<IActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        {
            try
            {
                var result = await this.collectionService.DeleteAsync<IAlbumModel>(ids);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
    }
}
