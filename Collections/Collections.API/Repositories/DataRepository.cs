using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Collections.API.Services.Interfaces.MongoDb;
using Collections.API.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Collections.API.Models;
using Collections.API.Helpers;

namespace Collections.API.Repositories
{
    /// <summary>
    /// Repository for data from Mongo DB
    /// </summary>
    /// <seealso cref="Collections.API.Repositories.Interfaces.IDataRepository" />
    public class DataRepository : IDataRepository
    {
        /// <summary>
        /// The data collection
        /// </summary>
        private readonly IDataCollection dataCollection;

        /// <summary>
        /// The query service
        /// </summary>
        private readonly IQueryService queryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository"/> class.
        /// </summary>
        /// <param name="queryService">The query service</param>
        /// <param name="dataCollection">The data collection</param>
        public DataRepository(IQueryService queryService, IDataCollection dataCollection)
        {
            this.queryService = queryService;
            this.dataCollection = dataCollection;
        }

        /// <summary>
        /// Gets the records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>All records of requested type</returns>
        public async Task<IEnumerable<TInterface>> GetAsync<TInterface, TModel>() where TModel : class, TInterface, new()
        {
            var filter = Builders<TInterface>.Filter.Eq("_t", (typeof(TModel).Name));

            var result = await this.dataCollection.FindManyAsync<TInterface>(filter);

            return result;
        }

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <param name="id">The Id of the record to be retrieved</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <returns>Retrieved record by it's Id</returns>
        public async Task<TInterface> GetByIdAsync<TInterface>(string id)
        {
            var filter = Builders<TInterface>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = await this.dataCollection.FindOneAsync<TInterface>(filter);

            return result;
        }

        /// <summary>
        /// Searches for the model provided.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="model">The advanced search model.</param>
        /// <returns>Results from the search</returns>
        public async Task<IEnumerable<TInterface>> PostSearchAsync<TInterface, TModel>(AdvancedSearchModel<TModel> model) where TModel : class, TInterface, new()
        {
            var filter = this.queryService.BuildQuery<TInterface, TModel>(model);

            var result = await this.dataCollection.FindManyAsync<TInterface>(filter);

            return result;
        }

        /// <summary>
        /// Posts multiple records asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PostMultipleAsync<TInterface, TModel>(IEnumerable<TModel> model) where TModel : class, TInterface, new()
        {
            try
            {
                await this.dataCollection.InsertManyAsync<TInterface, TModel>(model);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Patches specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model tyoe</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PatchAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new()
        {
            var dictionary = model.ToValueDictionary();

            var result = await this.dataCollection.UpdateOneAsync<TInterface>(new BsonDocument("_id", ObjectId.Parse(id)), new BsonDocument("$set", new BsonDocument(dictionary)));

            if (result.IsAcknowledged && (result.MatchedCount == 1 && result.ModifiedCount == 1))
            {
                return true;
            }
            else if (result.IsAcknowledged && result.MatchedCount == 1)
            {
                throw new Exception("Document found but failed to be replaced");
            }

            return false;
        }

        /// <summary>
        /// Puts specified record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model tyoe</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PutAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new()
        {
            var filter = Builders<TInterface>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = await this.dataCollection.ReplaceOneAsync<TInterface, TModel>(filter, model);

            if (result.IsAcknowledged && (result.MatchedCount == 1 && result.ModifiedCount == 1))
            {
                return true;
            }
            else if (result.IsAcknowledged && result.MatchedCount == 1)
            {
                throw new Exception("Document found but failed to be replaced");
            }

            return false;
        }

        /// <summary>
        /// Deletes specified records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> DeleteMultipleAsync<TInterface>(IEnumerable<string> ids)
        {
            var parsedIds = ids.Select(s => ObjectId.Parse(s));

            var filter = Builders<TInterface>.Filter.In("_id", parsedIds);

            var result = await this.dataCollection.DeleteManyAsync<TInterface>(filter);

            if (result.IsAcknowledged && result.DeletedCount >= 1)
            {
                return true;
            }
            else if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                throw new Exception("Request acknowledged but document failed to be deleted");
            }

            return false;
        }
    }
}