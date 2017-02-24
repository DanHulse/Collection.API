using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Collections.API.Controllers.V1
{
    public class MoviesController : BaseController
    {
        public MoviesController()
        {

        }

        public IHttpActionResult Get()
        {
            return this.Ok();
        }
    }
}