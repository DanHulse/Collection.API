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
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>All records of requested type</returns>
        Task<IEnumerable<T>> GetAsync<T, O>() where O : class, T, new();

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <param name="id">The Id of the record to be retrieved</param>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>Retrieved record by it's Id</returns>
        Task<T> GetByIdAsync<T, O>(string id) where O : class, T, new();

        /// <summary>
        /// Posts multiple records asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PostMultipleAsync<O>(IEnumerable<O> model);

        /// <summary>
        /// Patches specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync<O>(string id, O model);

        /// <summary>
        /// Puts specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> PutAsync<O>(string id, O model);

        /// <summary>
        /// Deletes specified records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        Task<bool> DeleteMultipleAsync<O>(IEnumerable<string> ids);
    }
}
