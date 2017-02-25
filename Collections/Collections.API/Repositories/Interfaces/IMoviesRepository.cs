using Collections.API.Models.Interfaces.Movies;
using Collections.API.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Posts the movie asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync(MovieModel model);
    }
}
