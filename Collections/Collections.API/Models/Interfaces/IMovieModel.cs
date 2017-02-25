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
    /// Interface for the Movie Model
    /// </summary>
    public interface IMovieModel
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
        /// Gets or sets the directors.
        /// </summary>
        List<string> Directors { get; set; }

        /// <summary>
        /// Gets or sets the cast.
        /// </summary>
        List<string> Cast { get; set; }

        /// <summary>
        /// Gets or sets the producers.
        /// </summary>
        List<string> Producers { get; set; }

        /// <summary>
        /// Gets or sets the writers.
        /// </summary>
        List<string> Writers { get; set; }

        /// <summary>
        /// Gets or sets the music.
        /// </summary>
        List<string> Music { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the running time.
        /// </summary>
        int RunningTime { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        string Rating { get; set; }

        /// <summary>
        /// Gets or sets the poster URL.
        /// </summary>
        Uri PosterUrl { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        string Series { get; set; }

        /// <summary>
        /// Gets or sets the series number.
        /// </summary>
        int SeriesNumber { get; set; }
    }
}
