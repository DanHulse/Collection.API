using System;

namespace Collections.API.ViewModels
{
    /// <summary>
    /// View model for Album data
    /// </summary>
    public class AlbumViewModel
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
        /// Gets or sets the album cover URL.
        /// </summary>
        public Uri AlbumCoverUrl { get; set; }
    }
}