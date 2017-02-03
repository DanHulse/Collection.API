using System.Data;
using Collection.API.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Collection.API.DtoModels.Interfaces;
using Collection.API.Models;

namespace Collection.API.Repositories
{
    /// <summary>
    /// Repository for movie collection data
    /// </summary>
    /// <seealso cref="Collection.API.Repositories.BaseRepository"/>
    /// <seealso cref="Collection.API.Repositories.Interfaces.IMoviesRepository" />
    public class MoviesRepository : BaseRepository, IMoviesRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesRepository"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public MoviesRepository(IDbConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets movies asynchronously.
        /// </summary>
        /// <returns><see cref="IEnumerable{IMovieDto}"/>of requeted movies from database</returns>
        public async Task<IEnumerable<IMovieDto>> GetAsync()
        {
            return null;
        }

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <returns><see cref="IMovieDto"/>of requested movie from database</returns>
        public async Task<IMovieDto> GetByIdAsync()
        {
            return null;
        }

        /// <summary>
        /// Posts movie to the server asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns>True if successful</returns>
        public async Task<bool> PostAsync(MovieModel movie)
        {
            return false;
        }

        /// <summary>
        /// Patches movie on the server asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if successful</returns>
        public async Task<bool> PatchAsync(MovieModel model)
        {
            return false;
        }
    }
}
