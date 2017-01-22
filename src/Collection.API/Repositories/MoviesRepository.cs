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
        /// <returns></returns>
        public async Task<IEnumerable<IMovieDto>> GetAsync()
        {
            return null;
        }

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IMovieDto> GetByIdAsync()
        {
            return null;
        }

        /// <summary>
        /// Posts movie to the server asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        public async Task<bool> PostAsync(MovieModel movie)
        {
            return false;
        }
    }
}
