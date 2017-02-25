using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.ViewModels.Movies
{
    /// <summary>
    /// View model for the movie data
    /// </summary>
    public class MovieViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        public DateTime LastModified { get; set; }
    }
}