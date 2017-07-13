using AutoMapper;
using Collections.API.Models.Interfaces;
using Collections.API.ViewModels;

namespace Collections.API.Mappings.Profiles
{
    /// <summary>
    /// Class for movie AutoMapper config profiles
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MoviesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesProfile"/> class.
        /// </summary>
        public MoviesProfile()
        {
            this.CreateMap<IMovieModel, MovieViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            this.CreateMap<IMovieModel, MovieDetailViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
