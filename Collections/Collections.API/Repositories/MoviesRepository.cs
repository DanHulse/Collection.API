using Collections.API.Factories;
using Collections.API.Factories.Interfaces;
using Collections.API.Models.Interfaces;
using Collections.API.Models;
using Collections.API.Repositories.Interfaces;
using Collections.API.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// The configuration service
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesRepository"/> class.
        /// </summary>
        /// <param name="configurationService">The configuration service</param>
        public MoviesRepository(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
            this.movieFactory = new MongoFactory<IMovieModel>(this.configurationService);
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
        /// Gets the requested movie asynchronously.
        /// </summary>
        /// <returns><see cref="IMovieModel"/>requeted movie</returns>
        public async Task<IMovieModel> GetByIdAsync(string id)
        {
            var filter = Builders<IMovieModel>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = await movieCollection.Find(filter).FirstAsync();

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
                model.Id = ObjectId.GenerateNewId().ToString();

                await movieCollection.InsertOneAsync(model);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Patches specified movie asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>True if successful</returns>
        public async Task<bool> PatchAsync(string id, MovieModel model)
        {
            var filter = Builders<IMovieModel>.Filter.Eq("_id", ObjectId.Parse(model.Id));

            var result = await movieCollection.ReplaceOneAsync(filter, model);

            if (result.IsAcknowledged && (result.MatchedCount == 1 && result.ModifiedCount == 1))
            {
                return true;
            }
            else if (result.IsAcknowledged && result.MatchedCount == 1)
            {
                throw new Exception("Document found but failed to be replaced");
            }

            return false;
        }

        /// <summary>
        /// Deletes specified movie asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>True if successful</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<IMovieModel>.Filter.Eq("_id", ObjectId.Parse(id));

            var result = await movieCollection.DeleteOneAsync(filter);

            if (result.IsAcknowledged && result.DeletedCount == 1)
            {
                return true;
            }
            else if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                throw new Exception("Request acknowledged but document failed to be deleted");
            }

            return false;
        }
    }
}