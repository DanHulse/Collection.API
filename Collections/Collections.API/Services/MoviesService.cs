using Collections.API.Repositories.Interfaces;
using Collections.API.Services.Interfaces;
using Collections.API.ViewModels.Movies;
using System.Collections.Generic;
using Collections.API.Mapper.Interfaces;
using System.Threading.Tasks;
using Collections.API.Models.Movies;

namespace Collections.API.Services
{
    /// <summary>
    /// The movies service
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.IMoviesService" />
    public class MoviesService : IMoviesService
    {
        /// <summary>
        /// The movies repository
        /// </summary>
        private readonly IMoviesRepository moviesRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesService"/> class.
        /// </summary>
        /// <param name="moviesRepository">The movies repository.</param>
        public MoviesService(IMoviesRepository moviesRepository, IMapper mapper)
        {
            this.moviesRepository = moviesRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the movies asynchronously.
        /// </summary>
        /// <returns><see cref="IEnumerable{MovieViewModel}"/>collection of movies</returns>
        public async Task<IEnumerable<MovieViewModel>> GetAsync()
        {
            var movies = await this.moviesRepository.GetAsync();

            var mappedMovies = mapper.Map<IEnumerable<MovieViewModel>>(movies);

            return mappedMovies;
        }

        /// <summary>
        /// Posts the movie model asynchronously
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns>True if successful</returns>
        public async Task<bool> PostAsync(MovieModel model)
        {
            var result = await this.moviesRepository.PostAsync(model);

            return result;
        }
    }
}