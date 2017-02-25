using Collections.API.Factories.Interfaces;
using Collections.API.Services.Interfaces;
using MongoDB.Driver;
using System.Security.Authentication;

namespace Collections.API.Factories
{
    /// <summary>
    /// Factory for connecting to the Document DB
    /// </summary>
    /// <typeparam name="T">Type of BSON Document</typeparam>
    /// <seealso cref="Collections.API.Factories.Interfaces.IMongoFactory{T}"/>
    public class MongoFactory<T> : IMongoFactory<T> where T : class
    {
        /// <summary>
        /// The configuration service
        /// </summary>
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// The MongoDB connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// The MongoDB collection
        /// </summary>
        private readonly string collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoFactory{T}"/> class.
        /// </summary>
        public MongoFactory(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
            this.connectionString = this.configurationService.GetAppSetting("MongoDbConnection");
            this.collection = this.configurationService.GetAppSetting("MongoDbCollection");
        }

        /// <summary>
        /// Connects to Document DB collection.
        /// </summary>
        /// <returns><see cref="IMongoCollection{TDocument}"/> of collection from DB</returns>
        public IMongoCollection<T> ConnectToCollection()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(this.connectionString));

            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            var db = mongoClient.GetDatabase(this.collection);

            return db.GetCollection<T>(typeof(T).Name.ToLower());
        }
    }
}