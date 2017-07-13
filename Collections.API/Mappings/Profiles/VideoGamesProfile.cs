using AutoMapper;
using Collections.API.Models.Interfaces;
using Collections.API.ViewModels;

namespace Collections.API.Mappings.Profiles
{
    /// <summary>
    /// Class for video game AutoMapper config profiles
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class VideoGamesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGamesProfile"/> class.
        /// </summary>
        public VideoGamesProfile()
        {
            this.CreateMap<IVideoGameModel, VideoGameViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            this.CreateMap<IVideoGameModel, VideoGameDetailViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
