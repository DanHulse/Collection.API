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
    /// Books collection controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.BaseController" />
    [RoutePrefix("api/v1/Books")]
    public class BooksController : BaseController
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
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="dataService">The data service</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="logger">The logger.</param>
        public BooksController(IDataService dataService, IMapper mapper, ILogger logger)
        {
            this.dataService = dataService;
            this.mapper = mapper;
            this.Logger = logger;
        }

        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of all books</returns>
        [HttpGet]
        [Route("", Name = "GetBooks")]
        [ResponseType(typeof(IEnumerable<BookViewModel>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var result = await this.dataService.GetAsync<IBookModel>();

                if (result.Any())
                {
                    var mappedResults = this.mapper.Map<IEnumerable<BookViewModel>>(result);

                    return this.Ok(mappedResults);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to retrive books");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieve requested book
        /// </summary>
        /// <returns><see cref="IHttpActionResult"/>of requested book</returns>
        [HttpGet]
        [Route("{id}", Name = "GetBooksById")]
        [ResponseType(typeof(BookDetailViewModel))]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri]string id)
        {
            try
            {
                var result = await this.dataService.GetByIdAsync<IBookModel>(id);

                if (result != null)
                {
                    var mappedResult = this.mapper.Map<BookDetailViewModel>(result);

                    return this.Ok(mappedResult);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to retrive book with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Insert new books to DB
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPost]
        [Route("", Name = "PostBooks")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PostAsync([FromBody]IEnumerable<BookModel> model)
        {
            try
            {
                foreach (var m in model)
                {
                    m.Id = ObjectId.GenerateNewId().ToString();
                }

                var result = await this.dataService.PostAsync<IBookModel, BookModel>(model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, "Failed to post the books");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates specified book
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpPatch]
        [Route("{id}", Name = "PatchBook")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> PatchAsync([FromUri]string id, [FromBody]BookModel model)
        {
            try
            {
                var result = await this.dataService.PatchAsync<IBookModel, BookModel>(id, model);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to patch book with Id: {id}");

                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the books asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers of the books to delete.</param>
        /// <returns><see cref="IHttpActionResult"/>OK if successful</returns>
        [HttpDelete]
        [Route("", Name = "DeleteBooks")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        {
            try
            {
                var result = await this.dataService.DeleteAsync<IBookModel>(ids);

                if (result)
                {
                    return this.Ok();
                }

                return this.BadRequest();
            }
            catch (Exception ex)
            {
                this.Logger.Log(LogLevel.Error, ex, $"Failed to delete books");

                return this.InternalServerError(ex);
            }
        }
    }
}