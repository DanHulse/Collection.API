using System.Data;
using Collection.API.Repositories.Interfaces;

namespace Collection.API.Repositories
{

    /// <summary>
    /// Represents an abstract repository used to inject connections.
    /// </summary>
    /// <seealso cref="Collection.API.Repositories.Interfaces.IRepository" />
    public abstract class BaseRepository : IRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        protected BaseRepository(IDbConnection connection)
        {
            this.Connection = connection;
        }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        protected IDbConnection Connection { get; set; }
    }
}
