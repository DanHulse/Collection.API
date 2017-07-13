using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Collections.API.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the data repository
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Finds one record asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrieved record</returns>
        Task<TInterface> FindOneAsync<TInterface>(FilterDefinition<TInterface> filter);

        /// <summary>
        /// Finds many records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrived records</returns>
        Task<IEnumerable<TInterface>> FindManyAsync<TInterface>(FilterDefinition<TInterface> filter);

        /// <summary>
        /// Inserts one record asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="model">The model.</param>
        Task InsertOneAsync<TInterface, TModel>(TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Inserts many records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="models">The models.</param>
        Task InsertManyAsync<TInterface, TModel>(IEnumerable<TModel> models) where TModel : class, TInterface, new();

        /// <summary>
        /// Updates one record asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="update">The update.</param>
        /// <returns><see cref="UpdateResult"/>result of update operation</returns>
        Task<UpdateResult> UpdateOneAsync<TInterface>(FilterDefinition<TInterface> filter, UpdateDefinition<TInterface> update);

        /// <summary>
        /// Replaces one document asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="ReplaceOneResult"/>result of replace operation</returns>
        Task<ReplaceOneResult> ReplaceOneAsync<TInterface, TModel>(FilterDefinition<TInterface> filter, TModel model) where TModel : class, TInterface, new();

        /// <summary>
        /// Deletes many records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns><see cref="DeleteResult"/>result of delete operation</returns>
        Task<DeleteResult> DeleteManyAsync<TInterface>(FilterDefinition<TInterface> filter);
    }
}
