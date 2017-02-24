namespace Collections.API.Infrastructure
{
    /// <summary>
    /// The Auto mapper profile config
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(
                x =>
                {
                });
        }
    }
}