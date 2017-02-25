﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.ViewModels
{
    /// <summary>
    /// View model for the movie data
    /// </summary>
    public class MovieViewModel
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
        /// Gets or sets the directors.
        /// </summary>
        public List<string> Directors { get; set; }

        /// <summary>
        /// Gets or sets the cast.
        /// </summary>
        public List<string> Cast { get; set; }

        /// <summary>
        /// Gets or sets the running time.
        /// </summary>
        public int RunningTime { get; set; }

        /// <summary>
        /// Gets or sets the poster URL.
        /// </summary>
        public Uri PosterUrl { get; set; }
    }
}