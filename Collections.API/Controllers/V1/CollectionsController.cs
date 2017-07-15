using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Collections.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Collections.API.Controllers.V1
{
    /// <summary>
    /// The Collections controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.BaseController" />
    [Route("api/v1/[controller]")]
    public class CollectionsController<TModel, TInterface, TView, TDetailView> : BaseController where TModel : class, TInterface, new()
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
        /// Initializes a new instance of the <see cref="CollectionsController{TModel, TInterface, TView, TDetailView}"/> class.
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
        public virtual async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await this.collectionService.GetAsync<TInterface, TModel>();

                if (result.Any())
                {
                    var mappedResults = this.mapper.Map<IEnumerable<TView>>(result);

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
        public virtual async Task<IActionResult> GetByIdAsync([FromRoute]string id)
        {
            try
            {
                var result = await this.collectionService.GetByIdAsync<TInterface>(id);

                if (result != null)
                {
                    var mappedResult = this.mapper.Map<TDetailView>(result);

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
        public virtual async Task<IActionResult> PostSearchAsync([FromBody]TModel model)
        {
            try
            {
                var result = await this.collectionService.PostSearchAsync<TInterface, TModel>(model);

                if (result.Any())
                {
                    var mappedResult = this.mapper.Map<IEnumerable<TView>>(result);

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
        public virtual async Task<IActionResult> PostAsync([FromBody]IEnumerable<TModel> model)
        {
            try
            {
                var result = await this.collectionService.PostAsync<TInterface, TModel>(model);

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
        public virtual async Task<IActionResult> PatchAsync([FromRoute]string id, [FromBody]TModel model)
        {
            try
            {
                var result = await this.collectionService.PatchAsync<TInterface, TModel>(id, model);

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
        public virtual async Task<IActionResult> PutAsync([FromRoute]string id, [FromBody]TModel model)
        {
            try
            {
                var result = await this.collectionService.PutAsync<TInterface, TModel>(id, model);

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
        public virtual async Task<IActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        {
            try
            {
                var result = await this.collectionService.DeleteAsync<TInterface>(ids);

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
