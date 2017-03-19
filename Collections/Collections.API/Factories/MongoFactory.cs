using System.Security.Authentication;
using Collections.API.Factories.Interfaces;
using Collections.API.Services.Interfaces;
using MongoDB.Driver;

namespace Collections.API.Factories
{
    /// <summary>
    /// Factory for connecting to the Document DB
    /// </summary>
    /// <seealso cref="Collections.API.Factories.Interfaces.IMongoFactory"/>
    public class MongoFactory : IMongoFactory
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
        /// Initializes a new instance of the <see cref="MongoFactory"/> class.
        /// </summary>
        /// <param name="configurationService">The configuration service.</param>
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
        public IMongoCollection<O> ConnectToCollection<O>()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(this.connectionString));

            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            var db = mongoClient.GetDatabase(this.collection);

            return db.GetCollection<O>(this.collection);
        }
    }
}