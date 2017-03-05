using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.API.Factories.Interfaces;
using Collections.API.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Collections.API.Infrastructure
{
    /// <summary>
    /// Wrapper class for the Mongo DB Collection
    /// </summary>
    /// <seealso cref="Collections.API.Infrastructure.Interfaces.IDataCollection" />
    public class DataCollection : IDataCollection
    {
        /// <summary>
        /// The mongo DB factory
        /// </summary>
        private readonly IMongoFactory mongoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataCollection"/> class.
        /// </summary>
        /// <param name="mongoFactory">The mongo DB factory.</param>
        public DataCollection(IMongoFactory mongoFactory)
        {
            this.mongoFactory = mongoFactory;
        }

        /// <summary>
        /// Finds one record asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrieved record</returns>
        public async Task<T> FindOneAsync<T>(FilterDefinition<T> filter)
        {
            return await this.RetrieveCollection<T>().Find(filter).FirstAsync();
        }

        /// <summary>
        /// Finds many records asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrived records</returns>
        public async Task<IEnumerable<T>> FindManyAsync<T>(FilterDefinition<T> filter)
        {
            return await this.RetrieveCollection<T>().Find(filter).ToListAsync();
        }

        /// <summary>
        /// Inserts one record asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="model">The model.</param>
        public async Task InsertOneAsync<T, O>(O model) where O : class, T, new()
        {
            await this.RetrieveCollection<T>().InsertOneAsync(model);
        }

        /// <summary>
        /// Inserts many records asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="models">The models.</param>
        public async Task InsertManyAsync<T, O>(IEnumerable<O> models) where O : class, T, new()
        {
            await this.RetrieveCollection<T>().InsertManyAsync(models);
        }

        /// <summary>
        /// Updates one record asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="update">The update.</param>
        /// <returns><see cref="UpdateResult"/>result of update operation</returns>
        public async Task<UpdateResult> UpdateOneAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            return await this.RetrieveCollection<T>().UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// Replaces one document asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="ReplaceOneResult"/>result of replace operation</returns>
        public async Task<ReplaceOneResult> ReplaceOneAsync<T, O>(FilterDefinition<T> filter, O model) where O : class, T, new()
        {
            return await this.RetrieveCollection<T>().ReplaceOneAsync(filter, model);
        }

        /// <summary>
        /// Deletes many records asynchronously.
        /// </summary>
        /// <typeparam name="T">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns><see cref="DeleteResult"/>result of delete operation</returns>
        public async Task<DeleteResult> DeleteManyAsync<T>(FilterDefinition<T> filter)
        {
            return await this.RetrieveCollection<T>().DeleteManyAsync(filter);
        }

        /// <summary>
        /// Retrieves the collection.
        /// </summary>
        /// <typeparam name="T">Model of collection</typeparam>
        /// <returns>Mongo DB collection</returns>
        private IMongoCollection<T> RetrieveCollection<T>()
        {
            return this.mongoFactory.ConnectToCollection<T>();
        }
    }
}