using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.API.Factories.Interfaces
{
    /// <summary>
    /// Interface for the Mongo DB Factory
    /// </summary>
    public interface IMongoFactory<T> : IFactory where T : class
    {
        /// <summary>
        /// Connects to Document DB collection.
        /// </summary>
        /// <returns><see cref="IMongoCollection{TDocument}"/> of collection from DB</returns>
        IMongoCollection<T> ConnectToCollection();
    }
}
