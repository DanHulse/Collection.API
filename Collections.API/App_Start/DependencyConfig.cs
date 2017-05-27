using Collections.API.App_Start.MongoDb;

namespace Collections.API.App_Start
{
    /// <summary>
    /// Configuration setup for external dependencies
    /// </summary>
    public class DependencyConfig
    {
        /// <summary>
        /// Configures the external dependencies.
        /// </summary>
        public static void Configure()
        {
            BsonMapConfig.Configure();
        }
    }
}