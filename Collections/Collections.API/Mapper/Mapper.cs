using Collections.API.Mapper.Interfaces;

namespace Collections.API.Mapper
{
    /// <summary>
    /// Maps object using AutoMapper.
    /// </summary>
    public class Mapper : IMapper
    {
        /// <summary>
        /// Maps object to that of type T.
        /// </summary>
        /// <typeparam name="T">Type that is being mapped to.</typeparam>
        /// <param name="mapFrom">The map from.</param>
        /// <returns>
        /// Instance of T.
        /// </returns>
        public T Map<T>(object mapFrom)
        {
            return AutoMapper.Mapper.Map<T>(mapFrom);
        }
    }
}