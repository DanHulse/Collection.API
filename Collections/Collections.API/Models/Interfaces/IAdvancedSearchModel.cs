namespace Collections.API.Models.Interfaces
{
    /// <summary>
    /// Interface for the advanced search model
    /// </summary>
    /// <typeparam name="T">The model the search will be performed against</typeparam>
    public interface IAdvancedSearchModel<T>
    {
        /// <summary>
        /// Gets or sets the included fields.
        /// </summary>
        T IncludedFields { get; set; }

        /// <summary>
        /// Gets or sets the excluded fields.
        /// </summary>
        T ExcludedFields { get; set; }
    }
}
