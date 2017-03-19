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
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns><see cref="IEnumerable{T}"/>collection of records</returns>
        Task<IEnumerable<T>> GetAsync<T, O>() where O : class, T, new();

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>The requested record</returns>
        Task<T> GetByIdAsync<T>(string id);

        /// <summary>
        /// Posts the record asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync<T, O>(IEnumerable<O> model) where O : class, T, new();

        /// <summary>
        /// Patches specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync<T, O>(string id, O model) where O : class, T, new();

        /// <summary>
        /// Puts specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PutAsync<T, O>(string id, O model) where O : class, T, new();

        /// <summary>
        /// Deletes specified the records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> DeleteAsync<T>(IEnumerable<string> ids);
    }
}
