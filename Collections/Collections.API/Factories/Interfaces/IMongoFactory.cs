using MongoDB.Driver;

namespace Collections.API.Factories.Interfaces
{
    /// <summary>
    /// Interface for the Mongo DB Factory
    /// </summary>
    public interface IMongoFactory : IFactory
    {
        /// <summary>
        /// Connects to Document DB collection.
        /// </summary>
        /// <returns><see cref="IMongoCollection{TDocument}"/> of collection from DB</returns>
        IMongoCollection<T> ConnectToCollection<T>();
    }
}
