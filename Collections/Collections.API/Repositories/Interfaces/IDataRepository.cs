using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collections.API.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the movies repository
    /// </summary>
    /// <seealso cref="Collections.API.Repositories.Interfaces.IRepository" />
    public interface IDataRepository : IRepository
    {
        /// <summary>
        /// Gets the records asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>All records of requested type</returns>
        Task<IEnumerable<T>> GetAsync<T>();

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <param name="id">The Id of the record to be retrieved</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>Retrieved record by it's Id</returns>
        Task<T> GetByIdAsync<T>(string id);

        /// <summary>
        /// Posts multiple records asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PostMultipleAsync<T, O>(IEnumerable<O> model) where O : class, T, new();

        /// <summary>
        /// Patches specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync<T, O>(string id, O model) where O : class, T, new();

        /// <summary>
        /// Puts specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PutAsync<T, O>(string id, O model) where O : class, T, new();

        /// <summary>
        /// Deletes specified records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> DeleteMultipleAsync<T>(IEnumerable<string> ids);
    }
}
