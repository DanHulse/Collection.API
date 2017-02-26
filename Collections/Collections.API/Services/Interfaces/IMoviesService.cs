using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.API.Models;
using Collections.API.ViewModels;

namespace Collections.API.Services.Interfaces
{
    /// <summary>
    /// Interface for the movies service
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.IService" />
    public interface IMoviesService : IService
    {
        /// <summary>
        /// Gets the movies asynchronously.
        /// </summary>
        /// <returns><see cref="IEnumerable{MovieViewModel}"/>collection of movies</returns>
        Task<IEnumerable<MovieViewModel>> GetAsync();

        /// <summary>
        /// Gets the requested movie asynchronously.
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns><see cref="MovieDetailViewModel"/>requested movie</returns>
        Task<MovieDetailViewModel> GetByIdAsync(string id);

        /// <summary>
        /// Posts the movie model asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync(IEnumerable<MovieModel> model);

        /// <summary>
        /// Patches specified the movie asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync(string id, MovieModel model);

        /// <summary>
        /// Deletes specified the movies asynchronously.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <returns>True if successful</returns>
        Task<bool> DeleteAsync(IEnumerable<string> ids);
    }
}
