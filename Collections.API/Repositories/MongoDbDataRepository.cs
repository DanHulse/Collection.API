using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.API.Factories.Interfaces;
using Collections.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace Collections.API.Repositories
{
    /// <summary>
    /// Repository for data from the document db
    /// </summary>
    /// <seealso cref="Collections.API.Repositories.Interfaces.IDataRepository" />
    public class MongoDbDataRepository : IDataRepository
    {
        /// <summary>
        /// The mongo DB factory
        /// </summary>
        private readonly IMongoDbFactory mongoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbDataRepository"/> class.
        /// </summary>
        /// <param name="mongoFactory">The mongo DB factory.</param>
        public MongoDbDataRepository(IMongoDbFactory mongoFactory)
        {
            this.mongoFactory = mongoFactory;
        }

        /// <summary>
        /// Finds one record asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrieved record</returns>
        public async Task<TInterface> FindOneAsync<TInterface>(FilterDefinition<TInterface> filter)
        {
            return await this.RetrieveCollection<TInterface>().Find(filter).FirstAsync();
        }

        /// <summary>
        /// Finds many records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns>Retrived records</returns>
        public async Task<IEnumerable<TInterface>> FindManyAsync<TInterface>(FilterDefinition<TInterface> filter)
        {
            return await this.RetrieveCollection<TInterface>().Find(filter).ToListAsync();
        }

        /// <summary>
        /// Inserts one record asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="model">The model.</param>
        public async Task InsertOneAsync<TInterface, TModel>(TModel model) where TModel : class, TInterface, new()
        {
            await this.RetrieveCollection<TInterface>().InsertOneAsync(model);
        }

        /// <summary>
        /// Inserts many records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="models">The models.</param>
        public async Task InsertManyAsync<TInterface, TModel>(IEnumerable<TModel> models) where TModel : class, TInterface, new()
        {
            await this.RetrieveCollection<TInterface>().InsertManyAsync(models);
        }

        /// <summary>
        /// Updates one record asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="update">The update.</param>
        /// <returns><see cref="UpdateResult"/>result of update operation</returns>
        public async Task<UpdateResult> UpdateOneAsync<TInterface>(FilterDefinition<TInterface> filter, UpdateDefinition<TInterface> update)
        {
            return await this.RetrieveCollection<TInterface>().UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// Replaces one document asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="model">The model.</param>
        /// <returns><see cref="ReplaceOneResult"/>result of replace operation</returns>
        public async Task<ReplaceOneResult> ReplaceOneAsync<TInterface, TModel>(FilterDefinition<TInterface> filter, TModel model) where TModel : class, TInterface, new()
        {
            return await this.RetrieveCollection<TInterface>().ReplaceOneAsync(filter, model);
        }

        /// <summary>
        /// Deletes many records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The filter type</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns><see cref="DeleteResult"/>result of delete operation</returns>
        public async Task<DeleteResult> DeleteManyAsync<TInterface>(FilterDefinition<TInterface> filter)
        {
            return await this.RetrieveCollection<TInterface>().DeleteManyAsync(filter);
        }

        /// <summary>
        /// Retrieves the collection.
        /// </summary>
        /// <typeparam name="TInterface">Model of collection</typeparam>
        /// <returns>Mongo DB collection</returns>
        private IMongoCollection<TInterface> RetrieveCollection<TInterface>()
        {
            return this.mongoFactory.ConnectToCollection<TInterface>();
        }
    }
}
