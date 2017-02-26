using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.API.Models.Interfaces
{
    /// <summary>
    /// Interface for the video game model
    /// </summary>
    public interface IVideoGameModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the translated title.
        /// </summary>
        string TranslatedTitle { get; set; }

        /// <summary>
        /// Gets or sets the developers.
        /// </summary>
        List<string> Developers { get; set; }

        /// <summary>
        /// Gets or sets the development studios.
        /// </summary>
        List<string> DevelopmentStudios { get; set; }

        /// <summary>
        /// Gets or sets the publishers.
        /// </summary>
        List<string> Publishers { get; set; }

        /// <summary>
        /// Gets or sets the platforms.
        /// </summary>
        List<string> Platforms { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the box art URL.
        /// </summary>
        Uri BoxArtUrl { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        string Series { get; set; }

        /// <summary>
        /// Gets or sets the series number.
        /// </summary>
        int SeriesNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="VideoGameModel"/> is finished.
        /// </summary>
        bool Finished { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        int Rating { get; set; }
    }
}
