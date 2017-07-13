using System.Security.Authentication;
using Collections.API.Factories.Interfaces;
using MongoDB.Driver;

namespace Collections.API.Factories
{
    /// <summary>
    /// The mongo db factory
    /// </summary>
    public class MongoDbFactory : IMongoDbFactory
    {
        /// <summary>
        /// The MongoDB connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// The MongoDB collection
        /// </summary>
        private readonly string collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbFactory"/> class.
        /// </summary>
        public MongoDbFactory(string ConnectionString, string CollectionName)
        {
            this.connectionString = ConnectionString;
            this.collection = CollectionName;
        }

        /// <summary>
        /// Connects to Document DB collection.
        /// </summary>
        /// <returns><see cref="IMongoCollection{TDocument}"/> of collection from DB</returns>
        public IMongoCollection<TInterface> ConnectToCollection<TInterface>()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(this.connectionString));

            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            var db = mongoClient.GetDatabase(this.collection);

            return db.GetCollection<TInterface>(this.collection);
        }
    }
}
