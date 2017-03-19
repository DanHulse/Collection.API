﻿using System.Collections.Generic;
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
    /// Books Controller
    /// </summary>
    /// <seealso cref="Collections.API.Controllers.V1.DataController{TInterface, TModel, TView, TDetail}" />
    [RoutePrefix("api/v1/Books")]
    public class BooksController : DataController<IBookModel, BookModel, BookViewModel, BookDetailViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public BooksController(IDataService dataService, IMapper mapper, ILogger logger)
            : base(dataService, mapper, logger)
        {
        }

        /// <summary>
        /// Retrieve all data records of the data type specified
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<BookViewModel>))]
        public override Task<IHttpActionResult> GetAsync()
        { return base.GetAsync(); }

        /// <summary>
        /// Retrieve requested record
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(BookDetailViewModel))]
        public override Task<IHttpActionResult> GetByIdAsync([FromUri]string id)
        { return base.GetByIdAsync(id); }

        /// <summary>
        /// Performs an advanced search function on the provided model
        /// </summary>
        [HttpPost]
        [Route("search")]
        [ResponseType(typeof(IEnumerable<BookViewModel>))]
        public override Task<IHttpActionResult> PostSearchAsync([FromBody]AdvancedSearchModel<BookModel> model)
        { return base.PostSearchAsync(model); }

        /// <summary>
        /// Insert new records to DB of specified type
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> PostAsync([FromBody]IEnumerable<BookModel> model)
        { return base.PostAsync(model); }

        /// <summary>
        /// Replaces the specified record with the new model
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> PutAsync([FromUri]string id, [FromBody]BookModel model)
        { return base.PutAsync(id, model); }

        /// <summary>
        /// Deletes the records of the specified type asynchronously.
        /// </summary>
        [HttpDelete]
        [Route("")]
        [ResponseType(typeof(IHttpActionResult))]
        public override Task<IHttpActionResult> DeleteAsync([FromBody]IEnumerable<string> ids)
        { return base.DeleteAsync(ids); }
    }
}
