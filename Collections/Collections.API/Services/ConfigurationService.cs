using Collections.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Collections.API.Services
{
    /// <summary>
    /// Service for the retrieval of configuration for the app
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.IConfigurationService" />
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// Gets the app setting after being passed a key.
        /// </summary>
        /// <param name="key">The key of the app setting that is being returned.</param>
        /// <returns>An app setting.</returns>
        public string GetAppSetting(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A connection string</returns>
        public string GetConnectionString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}