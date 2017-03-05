using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Collections.API.Infrastructure.Interfaces;
using Collections.API.Helpers;
using Collections.API.Repositories.Interfaces;
using Collections.API.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Collections.API.Repositories
{
    /// <summary>
    /// Repository for data from Mongp DB
    /// </summary>
    /// <seealso cref="Collections.API.Repositories.Interfaces.IDataRepository" />
    public class DataRepository : IDataRepository
    {
        /// <summary>
        /// The data collection
        /// </summary>
        private readonly IDataCollection dataCollection;

        /// <summary>
        /// The configuration service
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository"/> class.
        /// </summary>
        /// <param name="configurationService">The configuration service</param>
        /// <param name="dataCollection">The data collection</param>
        public DataRepository(IConfigurationService configurationService, IDataCollection dataCollection)
        {
            this.configurationService = configurationService;
            this.dataCollection = dataCollection;
        }

        /// <summary>
        /// Gets the records asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>All records of requested type</returns>
        public async Task<IEnumerable<T>> GetAsync<T>()
        {
            var result = await this.dataCollection.FindManyAsync<T>(new BsonDocument());

            return result;
        }

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <param name="id">The Id of the record to be retrieved</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>Retrieved record by it's Id</returns>
        public async Task<T> GetByIdAsync<T>(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = await this.dataCollection.FindOneAsync(filter);

            return result;
        }

        /// <summary>
        /// Posts multiple records asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PostMultipleAsync<T, O>(IEnumerable<O> model) where O : class, T, new()
        {
            try
            {
                await this.dataCollection.InsertManyAsync<T, O>(model);

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
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PatchAsync<T, O>(string id, O model) where O : class, T, new()
        {
            var dictionary = model.ToDictionary();
        
            var result = await this.dataCollection.UpdateOneAsync<T>(new BsonDocument("_id", ObjectId.Parse(id)), new BsonDocument("$set", new BsonDocument(dictionary)));

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
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PutAsync<T, O>(string id, O model) where O : class, T, new()
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = await this.dataCollection.ReplaceOneAsync<T, O>(filter, model);

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
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> DeleteMultipleAsync<T>(IEnumerable<string> ids)
        {
            var parsedIds = ids.Select(s => ObjectId.Parse(s));

            var filter = Builders<T>.Filter.In("_id", parsedIds);

            var result = await this.dataCollection.DeleteManyAsync<T>(filter);

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