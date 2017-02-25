using Collections.API.Mapper.Profiles;

namespace Collections.API.Infrastructure
{
    /// <summary>
    /// The Auto mapper profile config
    /// </summary>
    public class AutoMapConfig
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(
                x =>
                {
                    x.AddProfile<MoviesProfile>();
                });
        }
    }
}