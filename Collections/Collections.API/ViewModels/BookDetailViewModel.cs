using System;
using System.Collections.Generic;

namespace Collections.API.ViewModels
{
    /// <summary>
    /// View model for detailed book data
    /// </summary>
    public class BookDetailViewModel
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
        /// Gets or sets the authors.
        /// </summary>
        public List<string> Authors { get; set; }

        /// <summary>
        /// Gets or sets the ISBN13.
        /// </summary>
        public string ISBN13 { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the formats.
        /// </summary>
        public List<string> Formats { get; set; }

        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// Gets or sets the cover URL.
        /// </summary>
        public Uri CoverUrl { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Gets or sets the series number.
        /// </summary>
        public int SeriesNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BookDetailViewModel"/> is read.
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public int Rating { get; set; }
    }
}