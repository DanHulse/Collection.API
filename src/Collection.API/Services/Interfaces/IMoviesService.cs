using Collection.API.Models;
using Collection.API.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.API.Services.Interfaces
{
    /// <summary>
    /// Interface for the movies service
    /// </summary>
    /// <seealso cref="Collection.API.Services.Interfaces.IService" />
    public interface IMoviesService : IService
    {
        /// <summary>
        /// Gets the movies asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IMovieViewModel>> GetMoviesAsync();

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IMovieDetailViewModel> GetMovieByIdAsync();

        /// <summary>
        /// Posts the movie asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        Task<bool> PostMovieAsync(MovieModel movie);
    }
}
