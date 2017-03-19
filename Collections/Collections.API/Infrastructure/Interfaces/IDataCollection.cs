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
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrieved record</returns>
        Task<T> FindOneAsync<T, O>(FilterDefinition<O> filter) where O : class, T, new();

        /// <summary>
        /// Finds many records asynchronously.
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrived records</returns>
        Task<IEnumerable<T>> FindManyAsync<T, O>(FilterDefinition<O> filter) where O : class, T, new();

        /// <summary>
        /// Inserts one record asynchronously.
        /// </summary>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="model">The model.</param>
        Task InsertOneAsync<O>(O model);

        /// <summary>
        /// Inserts many records asynchronously.
        /// </summary>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="models">The models.</param>
        Task InsertManyAsync<O>(IEnumerable<O> models);

        /// <summary>
        /// Updates one record asynchronously.
        /// </summary>
        /// <typeparam name="O">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="update">The update.</param>
        /// <returns><see cref="UpdateResult"/>result of update operation</returns>
        Task<UpdateResult> UpdateOneAsync<O>(FilterDefinition<O> filter, UpdateDefinition<O> update);

        /// <summary>
        /// Replaces one document asynchronously.
        /// </summary>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="ReplaceOneResult"/>result of replace operation</returns>
        Task<ReplaceOneResult> ReplaceOneAsync<O>(FilterDefinition<O> filter, O model);

        /// <summary>
        /// Deletes many records asynchronously.
        /// </summary>
        /// <typeparam name="O">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns><see cref="DeleteResult"/>result of delete operation</returns>
        Task<DeleteResult> DeleteManyAsync<O>(FilterDefinition<O> filter);
    }
}
