using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Collections.API.Models;
using Collections.API.Models.Interfaces;
using Collections.API.ViewModels;
using Collections.API.Infrastructure.Interfaces;
using Collections.API.Mapper.Interfaces;
using Collections.API.Services.Interfaces;

namespace Collections.API.Controllers.V1
{
    /// <summary>
    /// Albums Controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.V1.DataController{T, O, S}" />
    [RoutePrefix("api/v1/Albums")]
    public class AlbumsController : DataController<IAlbumModel, AlbumModel, AlbumViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public AlbumsController(IDataService dataService, IMapper mapper, ILogger logger)
            : base(dataService, mapper, logger)
        {
        }

        /// <summary>
        /// Retrieve all data records of the data type specified
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> GetAsync() { return base.GetAsync(); }

        /// <summary>
        /// Retrieve requested record
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> GetByIdAsync([FromUri] string id) { return base.GetByIdAsync(id); }

        /// <summary>
        /// Insert new records to DB of specified type
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> PostAsync([FromBody] IEnumerable<AlbumModel> model) { return base.PostAsync(model); }

        /// <summary>
        /// Replaces the specified record with the new model
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> PutAsync([FromUri] string id, [FromBody] AlbumModel model) { return base.PutAsync(id, model); }

        /// <summary>
        /// Deletes the records of the specified type asynchronously.
        /// </summary>
        [HttpDelete]
        [Route("")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> DeleteAsync([FromBody] IEnumerable<string> ids) { return base.DeleteAsync(ids); }
    }
}
