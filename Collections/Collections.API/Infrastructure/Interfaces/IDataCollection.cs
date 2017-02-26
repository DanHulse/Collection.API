using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Collections.API.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for the Data Collection wrapper class
    /// </summary>
    public interface IDataCollection
    {
        /// <summary>
        /// Finds one record asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrieved record</returns>
        Task<T> FindOneAsync<T>(FilterDefinition<T> filter);

        /// <summary>
        /// Finds many records asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrived records</returns>
        Task<IEnumerable<T>> FindManyAsync<T>(FilterDefinition<T> filter);

        /// <summary>
        /// Inserts one record asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="model">The model.</param>
        Task InsertOneAsync<T, O>(O model) where O : class, T, new();

        /// <summary>
        /// Inserts many records asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="models">The models.</param>
        Task InsertManyAsync<T, O>(IEnumerable<O> models) where O : class, T, new();

        /// <summary>
        /// Updates one record asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="update">The update.</param>
        /// <returns><see cref="UpdateResult"/>result of update operation</returns>
        Task<UpdateResult> UpdateOneAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update);

        /// <summary>
        /// Deletes many records asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns><see cref="DeleteResult"/>result of delete operation</returns>
        Task<DeleteResult> DeleteManyAsync<T>(FilterDefinition<T> filter);
    }
}
