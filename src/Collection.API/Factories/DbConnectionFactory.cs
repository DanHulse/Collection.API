using Collection.API.Factories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Collection.API.Factories
{
    /// <summary>
    /// Class to provide database connections when required.
    /// </summary>
    public class DbConnectionFactory : IDbConnectionFactory
    {
        /// <summary>
        /// Connection string settings.
        /// </summary>
        private readonly string connectionStringSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbConnectionFactory"/> class.
        /// </summary>
        /// <param name="connectionStringSettings"> Connection String Settings.</param>
        public DbConnectionFactory(string connectionStringSettings)
        {
            this.connectionStringSettings = connectionStringSettings;
        }

        /// <summary>
        /// Gets a connection to the configured data source.
        /// </summary>
        /// <returns>A instance of the <see cref="IDbConnection"/> class.</returns>
        public IDbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(this.connectionStringSettings);
            connection.Open();

            return connection;
        }
    }
}
