using Collections.API.Models.Movies;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.Infrastructure
{
    /// <summary>
    /// The mapping config for Mongo DB BSON documents
    /// </summary>
    public class BsonMapConfig
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<MovieModel>(cm => { cm.AutoMap(); cm.SetIgnoreExtraElements(true); });
            //BsonClassMap.RegisterClassMap<IMovieModel>(cm => { cm.AutoMap(); cm.SetIgnoreExtraElements(true); });
        }
    }
}