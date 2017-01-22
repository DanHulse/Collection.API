using AutoMapper;
using Collection.API.DtoModels;
using Collection.API.ViewModels;

namespace Collection.API.Infrastructure
{
    /// <summary>
    /// Contains the auto mapper profiles
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoMapperProfileConfiguration : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfileConfiguration"/> class.
        /// </summary>
        public AutoMapperProfileConfiguration()
        {
            this.CreateMap<MovieDto, MovieViewModel>();
            this.CreateMap<MovieDto, MovieDetailViewModel>();
        }
    }
}
