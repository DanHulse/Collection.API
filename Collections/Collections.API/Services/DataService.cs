using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.API.Models;
using Collections.API.Repositories.Interfaces;
using Collections.API.Services.Interfaces;

namespace Collections.API.Services
{
    /// <summary>
    /// The data service
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.IDataService" />
    public class DataService : IDataService
    {
        /// <summary>
        /// The data repository
        /// </summary>
        private readonly IDataRepository dataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="dataRepository">The data repository.</param>
        public DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        /// <summary>
        /// Gets the records asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns><see cref="IEnumerable{T}"/>collection of records</returns>
        public async Task<IEnumerable<T>> GetAsync<T, O>() where O : class, T, new()
        {
            var results = await this.dataRepository.GetAsync<T, O>();

            return results;
        }

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>The requested record</returns>
        public async Task<T> GetByIdAsync<T>(string id)
        {
            var result = await this.dataRepository.GetByIdAsync<T>(id);

            return result;
        }

        /// <summary>
        /// Searches for the specified model with the advanced search model.
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="model">The advanced search model.</param>
        /// <returns>The results of the search</returns>
        public async Task<IEnumerable<T>> PostSearchAsync<T, O>(AdvancedSearchModel<O> model) where O : class, T, new()
        {
            var results = await this.dataRepository.PostSearchAsync<T, O>(model);

            return results;
        }

        /// <summary>
        /// Posts the record asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PostAsync<T, O>(IEnumerable<O> model) where O : class, T, new()
        {
            var result = await this.dataRepository.PostMultipleAsync<T, O>(model);

            return result;
        }

        /// <summary>
        /// Patches specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PatchAsync<T, O>(string id, O model) where O : class, T, new()
        {
            var result = await this.dataRepository.PatchAsync<T, O>(id, model);

            return result;
        }

        /// <summary>
        /// Puts specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PutAsync<T, O>(string id, O model) where O : class, T, new()
        {
            var result = await this.dataRepository.PutAsync<T, O>(id, model);

            return result;
        }

        /// <summary>
        /// Deletes specified the records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> DeleteAsync<T>(IEnumerable<string> ids)
        {
            var result = await this.dataRepository.DeleteMultipleAsync<T>(ids);

            return result;
        }
    }
}