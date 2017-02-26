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
using Collections.API.Models.Interfaces;
using Collections.API.Mapper.Interfaces;
using MongoDB.Bson;

namespace Collections.API.Controllers.V1
{
    /// <summary>
    /// Video games collection controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.BaseController" />
    [RoutePrefix("api/v1/VideoGames")]
    public class VideoGamesController : BaseController
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
        /// Initializes a new instance of the <see cref="VideoGamesController"/> class.
        /// </summary>
        /// <param name="dataService">The data service</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public VideoGamesController(IDataService dataService, IMapper mapper, ILogger logger)
        {
            this.dataService = dataService;
            this.mapper = mapper;
            this.Logger = logger;
        }

        /// <summary>
        /// Retrieve all video games
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of all video games</returns>
        [HttpGet]
        [Route("", Name = "GetVideoGames")]
        [ResponseType(typeof(IEnumerable<VideoGameViewModel>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var result = await this.dataService.GetAsync<IVideoGameModel>();

                if (result.Any())
                {
                    var mappedResult = this.mapper.Map<IEnumerable<VideoGameViewModel>>(result);

                    return this.Ok(mappedResult);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to retrive video games");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieve requested video game
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of requested video game</returns>
        [HttpGet]
        [Route("{id}", Name = "GetVideoGameById")]
        [ResponseType(typeof(VideoGameDetailViewModel))]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri]string id)
        {
            try
            {
                var result = await this.dataService.GetByIdAsync<IVideoGameModel>(id);

                if (result != null)
                {
                    var mappedResult = this.mapper.Map<VideoGameDetailViewModel>(result);

                    return this.Ok(result);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to retrive video game with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Insert new video games to DB
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPost]
        [Route("", Name = "PostVideoGames")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PostAsync([FromBody]IEnumerable<VideoGameModel> model)
        {
            try
            {
                foreach (var m in model)
                {
                    m.Id = ObjectId.GenerateNewId().ToString();
                }

                var result = await this.dataService.PostAsync<IVideoGameModel, VideoGameModel>(model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to post the video games");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates specified video game
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPatch]
        [Route("{id}", Name = "PatchVideoGame")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PatchAsync([FromUri]string id, [FromBody]VideoGameModel model)
        {
            try
            {
                var result = await this.dataService.PatchAsync<IVideoGameModel, VideoGameModel>(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to patch video game with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the video games asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers of the video games to delete.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpDelete]
        [Route("", Name = "DeleteVideoGames")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        {
            try
            {
                var result = await this.dataService.DeleteAsync<IVideoGameModel>(ids);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to delete video games");

                return this.InternalServerError(ex);
            }
        }
    }
}