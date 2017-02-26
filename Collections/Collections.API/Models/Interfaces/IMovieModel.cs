using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        /// Gets or sets the genres.
        /// </summary>
        List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the formats.
        /// </summary>
        List<string> Formats { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the running time.
        /// </summary>
        int? RunningTime { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Gets or sets the certification.
        /// </summary>
        string Certification { get; set; }

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
        int? SeriesNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MovieModel"/> is watched.
        /// </summary>
        bool? Watched { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        int? Rating { get; set; }
    }
}
