using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collections.API.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the collections repository
    /// </summary>
    public interface ICollectionRepository
    {
        /// <summary>
        /// Gets the records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>All records of requested type</returns>
        Task<IEnumerable<TInterface>> GetAsync<TInterface, TModel>() where TModel : class, TInterface, new();

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <param name="id">The Id of the record to be retrieved</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <returns>Retrieved record by it's Id</returns>
        Task<TInterface> GetByIdAsync<TInterface>(string id);

        /// <summary>
        /// Searches for the model provided.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="model">The advanced search model.</param>
        /// <returns>Results from the search</returns>
        Task<IEnumerable<TInterface>> PostSearchAsync<TInterface, TModel>(TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Posts multiple records asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PostMultipleAsync<TInterface, TModel>(IEnumerable<TModel> model) where TModel : class, TInterface, new();

        /// <summary>
        /// Patches specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model tyoe</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Puts specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model tyoe</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PutAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Deletes specified records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> DeleteMultipleAsync<TInterface>(IEnumerable<string> ids);
    }
}
