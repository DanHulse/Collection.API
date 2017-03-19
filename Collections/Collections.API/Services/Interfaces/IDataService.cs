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
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns><see cref="IEnumerable{T}"/>collection of records</returns>
        Task<IEnumerable<T>> GetAsync<T, O>() where O : class, T, new();

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>The requested record</returns>
        Task<T> GetByIdAsync<T, O>(string id) where O : class, T, new();

        /// <summary>
        /// Posts the record asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync<O>(IEnumerable<O> model);

        /// <summary>
        /// Patches specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync<O>(string id, O model);

        /// <summary>
        /// Puts specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PutAsync<O>(string id, O model);

        /// <summary>
        /// Deletes specified the records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> DeleteAsync<O>(IEnumerable<string> ids);
    }
}
