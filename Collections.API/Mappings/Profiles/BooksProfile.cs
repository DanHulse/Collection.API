using AutoMapper;
using Collections.API.Models.Interfaces;
using Collections.API.ViewModels;

namespace Collections.API.Mappings.Profiles
{
    /// <summary>
    /// Class for book AutoMapper config profiles
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class BooksProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksProfile"/> class.
        /// </summary>
        public BooksProfile()
        {
            this.CreateMap<IBookModel, BookViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            this.CreateMap<IBookModel, BookDetailViewModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
