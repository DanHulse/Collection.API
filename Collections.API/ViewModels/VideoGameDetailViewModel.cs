using System;
using System.Collections.Generic;

namespace Collections.API.ViewModels
{
    /// <summary>
    /// Detailed view model for data from the Video Games collection
    /// </summary>
    public class VideoGameDetailViewModel
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
        /// Gets or sets a value indicating whether this <see cref="VideoGameDetailViewModel"/> is finished.
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public int Rating { get; set; }
    }
}