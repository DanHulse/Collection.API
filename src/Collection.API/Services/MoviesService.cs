using AutoMapper;
using Collection.API.DtoModels.Interfaces;
using Collection.API.Models;
using Collection.API.Repositories.Interfaces;
using Collection.API.Services.Interfaces;
using Collection.API.ViewModels;
using Collection.API.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.API.Services
{
    /// <summary>
    /// Movies collection service
    /// </summary>
    /// <seealso cref="Collection.API.Services.Interfaces.IMoviesService" />
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
        /// <param name="mapper">The mapper</param>
        public MoviesService(IMoviesRepository moviesRepository, IMapper mapper)
        {
            this.moviesRepository = moviesRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all movies asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IMovieViewModel>> GetMoviesAsync()
        {
            var movies = await this.moviesRepository.GetAsync();

            var mappedMovies = movies.Select(m => this.mapper.Map<MovieViewModel>(movies));

            return mappedMovies;
        }

        /// <summary>
        /// Gets the movie by identifier asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IMovieDetailViewModel> GetMovieByIdAsync()
        {
            var movie = await this.moviesRepository.GetAsync();

            var mappedMovie = this.mapper.Map<MovieDetailViewModel>(movie);

            return mappedMovie;
        }

        /// <summary>
        /// Posts the movie to the server asynchronously.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns></returns>
        public async Task<bool> PostMovieAsync(MovieModel movie)
        {
            return await this.moviesRepository.PostAsync(movie);
        }
    }
}
