using Collections.API.Models.Interfaces;
using Collections.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collections.API.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the movies repository
    /// </summary>
    /// <seealso cref="Collections.API.Repositories.Interfaces.IRepository" />
    public interface IMoviesRepository : IRepository
    {
        /// <summary>
        /// Gets the movies asynchronously.
        /// </summary>
        /// <returns><see cref="IEnumerable{IMovieModel}"/>collection of movies</returns>
        Task<IEnumerable<IMovieModel>> GetAsync();

        /// <summary>
        /// Gets the requested movie asynchronously.
        /// </summary>
        /// <returns><see cref="IMovieModel"/>requeted movie</returns>
        Task<IMovieModel> GetByIdAsync(string id);

        /// <summary>
        /// Posts the movie asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync(MovieModel model);

        /// <summary>
        /// Patches specified movie asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync(string id, MovieModel model);

        /// <summary>
        /// Deletes specified movie asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>True if successful</returns>
        Task<bool> DeleteAsync(string id);
    }
}
