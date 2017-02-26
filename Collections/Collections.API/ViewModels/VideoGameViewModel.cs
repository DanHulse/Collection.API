using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.ViewModels
{
    /// <summary>
    /// View model for data from the Video Games collection
    /// </summary>
    public class VideoGameViewModel
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
        /// Gets or sets the box art URL.
        /// </summary>
        public Uri BoxArtUrl { get; set; }
    }
}