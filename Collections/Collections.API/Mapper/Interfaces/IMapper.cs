using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.API.Mapper.Interfaces
{
    /// <summary>
    /// Interface for mapper.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Maps object to that of type T.
        /// </summary>
        /// <typeparam name="T"> Type that is being mapped to.</typeparam>
        /// <param name="mapFrom">The map from.</param>
        /// <returns>Instance of T.</returns>
        T Map<T>(object mapFrom);
    }
}
