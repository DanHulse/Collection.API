using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Collections.API.Models.Interfaces
{
    /// <summary>
    /// Interface for the Album model
    /// </summary>
    public interface IAlbumModel
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
        /// Gets or sets the album artist.
        /// </summary>
        string AlbumArtist { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the producers.
        /// </summary>
        List<string> Producers { get; set; }

        /// <summary>
        /// Gets or sets the featured artists.
        /// </summary>
        List<string> FeaturedArtists { get; set; }

        /// <summary>
        /// Gets or sets the tracks.
        /// </summary>
        int? Tracks { get; set; }

        /// <summary>
        /// Gets or sets the discs.
        /// </summary>
        int? Discs { get; set; }

        /// <summary>
        /// Gets or sets the formats.
        /// </summary>
        List<string> Formats { get; set; }

        /// <summary>
        /// Gets or sets the released date.
        /// </summary>
        DateTime? ReleasedDate { get; set; }

        /// <summary>
        /// Gets or sets the album cover URL.
        /// </summary>
        Uri AlbumCoverUrl { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        int? Rating { get; set; }
    }
}
