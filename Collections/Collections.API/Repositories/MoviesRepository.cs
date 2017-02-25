using Collections.API.Models.Interfaces.Movies;
using Collections.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Collections.API.Repositories
{
    /// <summary>
    /// Repository for movie data
    /// </summary>
    /// <seealso cref="Collections.API.Repositories.Interfaces.IMoviesRepository" />
    public class MoviesRepository : IMoviesRepository
    {
        /// <summary>
        /// The movie collection
        /// </summary>
        private readonly IMongoCollection<IMovieModel> movieCollection;

        //private readonly IMongoFactory m

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesRepository"/> class.
        /// </summary>
        /// <param name="movieCollection">The movie collection</param>
        public MoviesRepository(IMongoCollection<IMovieModel> movieCollection)
        {
            this.movieCollection = movieCollection;
        }

        /// <summary>
        /// Gets the movies asynchronously.
        /// </summary>
        /// <returns><see cref="IEnumerable{IMovieModel}"/>collection of movies</returns>
        public async Task<IEnumerable<IMovieModel>> GetAsync()
        {
            //var movies = await Collection.F

            return null;
        }
    }
}