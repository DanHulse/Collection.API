using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.API.Models.Interfaces.Movies
{
    /// <summary>
    /// Interface for the Movie Model
    /// </summary>
    public interface IMovieModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonId]
        ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        DateTime LastModified { get; set; }
    }
}
