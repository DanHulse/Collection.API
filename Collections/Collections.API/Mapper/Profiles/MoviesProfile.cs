using AutoMapper;
using Collections.API.Models.Interfaces.Movies;
using Collections.API.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.Mapper.Profiles
{
    /// <summary>
    /// Class for movies AutoMapper config profiles
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
        }
    }
}