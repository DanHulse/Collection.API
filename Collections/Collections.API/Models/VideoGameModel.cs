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
    /// Model for video game data from the collection
    /// </summary>
    /// <seealso cref="Collections.API.Models.Interfaces.IVideoGameModel" />
    public class VideoGameModel : IVideoGameModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the translated title.
        /// </summary>
        public string TranslatedTitle { get; set; }

        /// <summary>
        /// Gets or sets the developers.
        /// </summary>
        public List<string> Developers { get; set; }

        /// <summary>
        /// Gets or sets the development studios.
        /// </summary>
        public List<string> DevelopmentStudios { get; set; }

        /// <summary>
        /// Gets or sets the publishers.
        /// </summary>
        public List<string> Publishers { get; set; }

        /// <summary>
        /// Gets or sets the platforms.
        /// </summary>
        public List<string> Platforms { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the box art URL.
        /// </summary>
        public Uri BoxArtUrl { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Gets or sets the series number.
        /// </summary>
        public int SeriesNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="VideoGameModel"/> is finished.
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public int Rating { get; set; }
    }
}