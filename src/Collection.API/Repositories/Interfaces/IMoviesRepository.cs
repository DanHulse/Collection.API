using Collection.API.DtoModels.Interfaces;
using Collection.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.API.Repositories.Interfaces
{
    /// <summary>
    /// Interface for the movies repository
    /// </summary>
    public interface IMoviesRepository
    {
        /// <summary>
        /// Gets movies asynchronously.
        /// </summary>
        /// <returns><see cref="IEnumerable{IMovieDto}"/>of requeted movies from database</returns>
        Task<IEnumerable<IMovieDto>> GetAsync();

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <returns><see cref="IMovieDto"/>of requested movie from database</returns>
        Task<IMovieDto> GetByIdAsync();

        /// <summary>
        /// Posts movie to the server asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync(MovieModel movie);

        /// <summary>
        /// Patches movie on the server asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if successful</returns>
        Task<bool> PatchAsync(MovieModel model);
    }
}
