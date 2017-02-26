using Collections.API.Models;
using MongoDB.Bson.Serialization;

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
            BsonClassMap.RegisterClassMap<VideoGameModel>(cm => { cm.AutoMap(); cm.SetIgnoreExtraElements(true); });
            BsonClassMap.RegisterClassMap<BookModel>(cm => { cm.AutoMap(); cm.SetIgnoreExtraElements(true); });
            BsonClassMap.RegisterClassMap<AlbumModel>(cm => { cm.AutoMap(); cm.SetIgnoreExtraElements(true); });
        }
    }
}