using Collections.API.Factories.Interfaces;
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
        /// Initializes a new instance of the <see cref="MongoFactory{T}"/> class.
        /// </summary>
        public MongoFactory()
        {
        }

        /// <summary>
        /// Connects to Document DB collection.
        /// </summary>
        /// <returns><see cref="IMongoCollection{TDocument}"/> of collection from DB</returns>
        public IMongoCollection<T> ConnectToCollection()
        {
            string connectionString = @"mongodb://collections:H1dB0O8JlKK096sbxMWkuBE3dzOomHwzyQHtmHduz1I85MIhMmYFFd7kxICEXqQIdj7PvMRlZiEJAWwmcauJLQ==@collections.documents.azure.com:10250/?ssl=true&sslverifycertificate=false";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));

            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            var db = mongoClient.GetDatabase("Collections");

            return db.GetCollection<T>(typeof(T).Name.ToLower());
        }
    }
}