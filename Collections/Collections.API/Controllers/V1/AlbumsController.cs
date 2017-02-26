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
using Collections.API.Mapper.Interfaces;
using Collections.API.Models.Interfaces;
using MongoDB.Bson;

namespace Collections.API.Controllers.V1
{
    /// <summary>
    /// Albums collection controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.BaseController" />
    [RoutePrefix("api/v1/Albums")]
    public class AlbumsController : BaseController
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
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="dataService">The data service</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="logger">The logger.</param>
        public AlbumsController(IDataService dataService, IMapper mapper, ILogger logger)
        {
            this.dataService = dataService;
            this.mapper = mapper;
            this.Logger = logger;
        }

        /// <summary>
        /// Retrieve all albums
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of all albums</returns>
        [HttpGet]
        [Route("", Name = "GetAlbums")]
        [ResponseType(typeof(IEnumerable<AlbumViewModel>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var result = await this.dataService.GetAsync<IAlbumModel>();

                if (result.Any())
                {
                    var mappedResults = this.mapper.Map<IEnumerable<AlbumViewModel>>(result);

                    return this.Ok(mappedResults);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to retrive albums");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieve requested album
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of requested album</returns>
        [HttpGet]
        [Route("{id}", Name = "GetAlbumsById")]
        [ResponseType(typeof(AlbumDetailViewModel))]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri]string id)
        {
            try
            {
                var result = await this.dataService.GetByIdAsync<IAlbumModel>(id);

                if (result != null)
                {
                    var mappedResult = this.mapper.Map<AlbumDetailViewModel>(result);

                    return this.Ok(mappedResult);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to retrive album with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Insert new albums to DB
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPost]
        [Route("", Name = "PostAlbums")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PostAsync([FromBody]IEnumerable<AlbumModel> model)
        {
            try
            {
                foreach (var m in model)
                {
                    m.Id = ObjectId.GenerateNewId().ToString();
                }

                var result = await this.dataService.PostAsync<IAlbumModel, AlbumModel>(model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to post the albums");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates specified album
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPatch]
        [Route("{id}", Name = "PatchAlbum")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PatchAsync([FromUri]string id, [FromBody]AlbumModel model)
        {
            try
            {
                var result = await this.dataService.PatchAsync<IAlbumModel, AlbumModel>(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to patch album with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the albums asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers of the albums to delete.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpDelete]
        [Route("", Name = "DeleteAlbums")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        {
            try
            {
                var result = await this.dataService.DeleteAsync<IAlbumModel>(ids);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to delete albums");

                return this.InternalServerError(ex);
            }
        }
    }
}