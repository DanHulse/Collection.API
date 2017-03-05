using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Collections.API.Enumerations;
using Collections.API.Infrastructure.Interfaces;
using Collections.API.Services.Interfaces;
using Collections.API.Mapper.Interfaces;

namespace Collections.API.Controllers.V1
{
    /// <summary>
    /// Data collections controller
    /// </summary>
    /// <typeparam name="T">The inteface type</typeparam>
    /// <typeparam name="O">The model type</typeparam>
    /// <typeparam name="S">The view model type</typeparam>
    /// <seealso cref="Collections.API.Controllers.BaseController" />
    public class DataController<T, O, S> : BaseController where O : class, T, new()
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
        /// Initializes a new instance of the <see cref="DataController{T, O, S}"/> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public DataController(IDataService dataService, IMapper mapper, ILogger logger)
        {
            this.dataService = dataService;
            this.mapper = mapper;
            this.Logger = logger;
        }

        /// <summary>
        /// Retrieve all data records of the data type specified
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of all records</returns>
        public virtual async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var result = await this.dataService.GetAsync<T>();

                if (result.Any())
                {
                    var mappedResults = this.mapper.Map<IEnumerable<S>>(result);

                    return this.Ok(mappedResults);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to retrive records");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieve requested record
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of requested record</returns>
        public virtual async Task<IHttpActionResult> GetByIdAsync([FromUri]string id)
        {
            try
            {
                var result = await this.dataService.GetByIdAsync<T>(id);

                if (result != null)
                {
                    var mappedResult = this.mapper.Map<S>(result);

                    return this.Ok(mappedResult);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to retrive record with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Insert new records to DB of specified type
        /// </summary>
        /// <param name="model">The record to be posted</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        public virtual async Task<IHttpActionResult> PostAsync([FromBody]IEnumerable<O> model)
        {
            try
            {
                var result = await this.dataService.PostAsync<T, O>(model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to post the records");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates specified record
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        public virtual async Task<IHttpActionResult> PatchAsync([FromUri]string id, [FromBody]O model)
        {
            try
            {
                var result = await this.dataService.PatchAsync<T, O>(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to patch record with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Replaces the specified record with the new model
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        public virtual async Task<IHttpActionResult> PutAsync([FromUri]string id, [FromBody]O model)
        {
            try
            {
                var result = await this.dataService.PutAsync<T, O>(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to put record with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the records of the specified type asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers of the records to delete.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        public virtual async Task<IHttpActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        {
            try
            {
                var result = await this.dataService.DeleteAsync<T>(ids);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to delete records");

                return this.InternalServerError(ex);
            }
        }
    }
}