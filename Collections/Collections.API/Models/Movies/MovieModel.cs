using Collections.API.Models.Interfaces.Movies;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.Models.Movies
{
    /// <summary>
    /// Model for Movie data
    /// </summary>
    public class MovieModel : IMovieModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        public DateTime LastModified { get; set; }
    }
}