using System;
using System.Collections.Generic;

namespace Collections.API.ViewModels
{
    /// <summary>
    /// Detailed view model for Album data
    /// </summary>
    public class AlbumDetailViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
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
        /// Gets or sets the album artist.
        /// </summary>
        public string AlbumArtist { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the producers.
        /// </summary>
        public List<string> Producers { get; set; }

        /// <summary>
        /// Gets or sets the featured artists.
        /// </summary>
        public List<string> FeaturedArtists { get; set; }

        /// <summary>
        /// Gets or sets the tracks.
        /// </summary>
        public int Tracks { get; set; }

        /// <summary>
        /// Gets or sets the discs.
        /// </summary>
        public int Discs { get; set; }

        /// <summary>
        /// Gets or sets the formats.
        /// </summary>
        public List<string> Formats { get; set; }

        /// <summary>
        /// Gets or sets the released date.
        /// </summary>
        public DateTime ReleasedDate { get; set; }

        /// <summary>
        /// Gets or sets the album cover URL.
        /// </summary>
        public Uri AlbumCoverUrl { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public int Rating { get; set; }
    }
}