namespace Collections.API.ViewModels
{
    /// <summary>
    /// View model for the links generated for HATEOAS
    /// </summary>
    public class LinkViewModel
    {
        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the relative.
        /// </summary>
        public string Rel { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkViewModel"/> class.
        /// </summary>
        /// <param name="href">The href.</param>
        /// <param name="rel">The relative.</param>
        /// <param name="method">The method.</param>
        public LinkViewModel(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }
    }
}
