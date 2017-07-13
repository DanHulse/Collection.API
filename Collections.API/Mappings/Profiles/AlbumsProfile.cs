using AutoMapper;
using Collections.API.Models.Interfaces;
using Collections.API.ViewModels;

namespace Collections.API.Mappings.Profiles
{
    /// <summary>
    /// Class for album AutoMapper config profiles
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AlbumsProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsProfile"/> class.
        /// </summary>
        public AlbumsProfile()
        {
            this.CreateMap<IAlbumModel, AlbumViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            this.CreateMap<IAlbumModel, AlbumDetailViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
