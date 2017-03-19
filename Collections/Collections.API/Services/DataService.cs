using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns><see cref="IEnumerable{T}"/>collection of records</returns>
        public async Task<IEnumerable<T>> GetAsync<T, O>() where O : class, T, new()
        {
            var results = await this.dataRepository.GetAsync<T, O>();

            return results;
        }

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>The requested record</returns>
        public async Task<T> GetByIdAsync<T, O>(string id) where O : class, T, new()
        {
            var result = await this.dataRepository.GetByIdAsync<T, O>(id);

            return result;
        }

        /// <summary>
        /// Posts the record asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PostAsync<O>(IEnumerable<O> model)
        {
            var result = await this.dataRepository.PostMultipleAsync<O>(model);

            return result;
        }

        /// <summary>
        /// Patches specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PatchAsync<O>(string id, O model)
        {
            var result = await this.dataRepository.PatchAsync<O>(id, model);

            return result;
        }

        /// <summary>
        /// Puts specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PutAsync<O>(string id, O model)
        {
            var result = await this.dataRepository.PutAsync<O>(id, model);

            return result;
        }

        /// <summary>
        /// Deletes specified the records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="O">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> DeleteAsync<O>(IEnumerable<string> ids)
        {
            var result = await this.dataRepository.DeleteMultipleAsync<O>(ids);

            return result;
        }
    }
}