using Collections.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collections.API.Services.Interfaces
{
    /// <summary>
    /// Interface for the data service
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.IService" />
    public interface IDataService : IService
    {
        /// <summary>
        /// Gets the records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns><see cref="IEnumerable{TInterface}"/>collection of records</returns>
        Task<IEnumerable<TInterface>> GetAsync<TInterface, TModel>() where TModel : class, TInterface, new();

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>The requested record</returns>
        Task<T> GetByIdAsync<T>(string id);

        /// <summary>
        /// Searches for the specified model with the advanced search model.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="model">The advanced search model.</param>
        /// <returns>The results of the search</returns>
        Task<IEnumerable<TInterface>> PostSearchAsync<TInterface, TModel>(TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Posts the record asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync<TInterface, TModel>(IEnumerable<TModel> model) where TModel : class, TInterface, new();

        /// <summary>
        /// Patches specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Puts specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PutAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Deletes specified the records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> DeleteAsync<TInterface>(IEnumerable<string> ids);
    }
}
