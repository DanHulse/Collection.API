using Collections.API.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.Models
{
    /// <summary>
    /// Model for movie data
    /// </summary>
    /// <seealso cref="Collections.API.Models.Interfaces.IMovieModel" />
    public class MovieModel : IMovieModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the translated title.
        /// </summary>
        public string TranslatedTitle { get; set; }

        /// <summary>
        /// Gets or sets the directors.
        /// </summary>
        public List<string> Directors { get; set; }

        /// <summary>
        /// Gets or sets the cast.
        /// </summary>
        public List<string> Cast { get; set; }

        /// <summary>
        /// Gets or sets the producers.
        /// </summary>
        public List<string> Producers { get; set; }

        /// <summary>
        /// Gets or sets the writers.
        /// </summary>
        public List<string> Writers { get; set; }

        /// <summary>
        /// Gets or sets the music.
        /// </summary>
        public List<string> Music { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the running time.
        /// </summary>
        public int RunningTime { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the poster URL.
        /// </summary>
        public Uri PosterUrl { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Gets or sets the series number.
        /// </summary>
        public int SeriesNumber { get; set; }
    }
}