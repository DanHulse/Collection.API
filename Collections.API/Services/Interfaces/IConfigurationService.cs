namespace Collections.API.Services.Interfaces
{
    /// <summary>
    /// Interface for the configuration service
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.IService" />
    public interface IConfigurationService : IService
    {
        /// <summary>
        /// Gets the app setting after being passed a key.
        /// </summary>
        /// <param name="key">The key of the app setting that is being returned.</param>
        /// <returns>An app setting.</returns>
        string GetAppSetting(string key);

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A connection string</returns>
        string GetConnectionString(string key);
    }
}
