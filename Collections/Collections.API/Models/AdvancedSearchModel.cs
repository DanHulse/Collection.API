using Collections.API.Models.Interfaces;

namespace Collections.API.Models
{
    /// <summary>
    /// Model for the advanced search capability
    /// </summary>
    /// <typeparam name="T">The model the search will be performed against</typeparam>
    /// <seealso cref="Collections.API.Models.Interfaces.IAdvancedSearchModel{T}" />
    public class AdvancedSearchModel<T> : IAdvancedSearchModel<T>
    {
        /// <summary>
        /// Gets or sets the included fields.
        /// </summary>
        public T IncludedFields { get; set; }

        /// <summary>
        /// Gets or sets the excluded fields.
        /// </summary>
        public T ExcludedFields { get; set; }
    }
}