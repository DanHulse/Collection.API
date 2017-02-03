using Collection.API.Models;
using Collection.API.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        /// <returns><see cref="IEnumerable{IMovieViewModel}"/>of requested movies from collection</returns>
        Task<IEnumerable<IMovieViewModel>> GetMoviesAsync();

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <returns><see cref="IMovieDetailViewModel"/>requested movie from collection</returns>
        Task<IMovieDetailViewModel> GetMovieByIdAsync();

        /// <summary>
        /// Posts the movie asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns><see cref="IActionResult"/>result of POST</returns>
        Task<bool> PostMovieAsync(MovieModel movie);

        /// <summary>
        /// Patches the movie asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns><see cref="IActionResult"/>result of PATCH</returns>
        Task<bool> PatchMovieAsync(MovieModel movie);
    }
}
