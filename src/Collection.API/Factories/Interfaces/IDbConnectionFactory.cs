using System.Data;

namespace Collection.API.Factories.Interfaces
{
    /// <summary>
    /// Interface for the Db connection factory
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// Gets a connection to the configured data source.
        /// </summary>
        /// <returns>A instance of the <see cref="IDbConnection"/> class.</returns>
        IDbConnection GetOpenConnection();
    }
}
