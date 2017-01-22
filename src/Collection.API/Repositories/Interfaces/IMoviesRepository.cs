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
        /// <returns></returns>
        Task<IEnumerable<IMovieDto>> GetAsync();

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IMovieDto> GetByIdAsync();

        /// <summary>
        /// Posts movie to the server asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        Task<bool> PostAsync(MovieModel movie);
    }
}
