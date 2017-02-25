using Collections.API.Factories;
using Collections.API.Factories.Interfaces;
using Collections.API.Models.Interfaces.Movies;
using Collections.API.Models.Movies;
using Collections.API.Repositories.Interfaces;
using MongoDB.Bson;
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
        /// The movie factory
        /// </summary>
        private readonly IMongoFactory<IMovieModel> movieFactory;

        /// <summary>
        /// The movie collection
        /// </summary>
        private readonly IMongoCollection<IMovieModel> movieCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesRepository"/> class.
        /// </summary>
        public MoviesRepository()
        {
            this.movieFactory = new MongoFactory<IMovieModel>();
            this.movieCollection = this.movieFactory.ConnectToCollection();
        }

        /// <summary>
        /// Gets the movies asynchronously.
        /// </summary>
        /// <returns><see cref="IEnumerable{IMovieModel}"/>collection of movies</returns>
        public async Task<IEnumerable<IMovieModel>> GetAsync()
        {
            var result = await movieCollection.Find(new BsonDocument()).ToListAsync();

            return result;
        }

        /// <summary>
        /// Posts the movie asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns>True if successful</returns>
        public async Task<bool> PostAsync(MovieModel model)
        {
            try
            {
                await movieCollection.InsertOneAsync(model);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}