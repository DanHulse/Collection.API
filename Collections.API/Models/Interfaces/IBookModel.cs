using System;
using System.Collections.Generic;

namespace Collections.API.Models.Interfaces
{
    /// <summary>
    /// Interface for the book model
    /// </summary>
    public interface IBookModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
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
        /// Gets or sets the authors.
        /// </summary>
        List<string> Authors { get; set; }

        /// <summary>
        /// Gets or sets the ISBN13.
        /// </summary>
        string ISBN13 { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the formats.
        /// </summary>
        List<string> Formats { get; set; }

        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        DateTime? PublishedDate { get; set; }

        /// <summary>
        /// Gets or sets the cover URL.
        /// </summary>
        Uri CoverUrl { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        string Series { get; set; }

        /// <summary>
        /// Gets or sets the series number.
        /// </summary>
        int? SeriesNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BookModel"/> is read.
        /// </summary>
        bool? Read { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        int? Rating { get; set; }
    }
}
