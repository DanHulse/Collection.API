using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections.API.Repositories.Interfaces;
using Collections.API.Services.Interfaces;

namespace Collections.API.Services
{
    /// <summary>
    /// The collections service
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.ICollectionService" />
    public class CollectionService : ICollectionService
    {
        /// <summary>
        /// The collections repository
        /// </summary>
        private readonly ICollectionRepository collectionRepository;

        /// <summary>
        /// Initializes a new instance TModelf the <see cref="CollectionService"/> class.
        /// </summary>
        /// <param name="collectionRepository">The data repository.</param>
        public CollectionService(ICollectionRepository collectionRepository)
        {
            this.collectionRepository = collectionRepository;
        }

        /// <summary>
        /// Gets the records asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns><see cref="IEnumerable{T}"/>collection TModelf records</returns>
        public async Task<IEnumerable<TInterface>> GetAsync<TInterface, TModel>() where TModel : class, TInterface, new()
        {
            var results = await this.collectionRepository.GetAsync<TInterface, TModel>();

            return results;
        }

        /// <summary>
        /// Gets the requested record asynchronously.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <returns>The requested record</returns>
        public async Task<TInterface> GetByIdAsync<TInterface>(string id)
        {
            var result = await this.collectionRepository.GetByIdAsync<TInterface>(id);

            return result;
        }

        /// <summary>
        /// Searches for the specified model with the advanced search model.
        /// </summary>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="model">The advanced search model.</param>
        /// <returns>The results TModelf the search</returns>
        public async Task<IEnumerable<TInterface>> PostSearchAsync<TInterface, TModel>(TModel model) where TModel : class, TInterface, new()
        {
            var results = await this.collectionRepository.PostSearchAsync<TInterface, TModel>(model);

            return results;
        }

        /// <summary>
        /// Posts the record asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PostAsync<TInterface, TModel>(IEnumerable<TModel> model) where TModel : class, TInterface, new()
        {
            var result = await this.collectionRepository.PostMultipleAsync<TInterface, TModel>(model);

            return result;
        }

        /// <summary>
        /// Patches specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PatchAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new()
        {
            var result = await this.collectionRepository.PatchAsync<TInterface, TModel>(id, model);

            return result;
        }

        /// <summary>
        /// Puts specified the record asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> PutAsync<TInterface, TModel>(string id, TModel model) where TModel : class, TInterface, new()
        {
            var result = await this.collectionRepository.PutAsync<TInterface, TModel>(id, model);

            return result;
        }

        /// <summary>
        /// Deletes specified the records asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <typeparam name="TInterface">The collection type</typeparam>
        /// <returns>True if successful</returns>
        public async Task<bool> DeleteAsync<TInterface>(IEnumerable<string> ids)
        {
            var result = await this.collectionRepository.DeleteMultipleAsync<TInterface>(ids);

            return result;
        }
    }
}
