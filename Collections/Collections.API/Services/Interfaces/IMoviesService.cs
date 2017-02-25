using Collections.API.Models.Movies;
using Collections.API.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns><see cref="IEnumerable{MovieViewModel}"/>collection of movies</returns>
        Task<IEnumerable<MovieViewModel>> GetAsync();

        /// <summary>
        /// Posts the movie model asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns>True if successful</returns>
        Task<bool> PostAsync(MovieModel model);
    }
}
