using Collections.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.API.Services.Interfaces.MongoDb
{
    /// <summary>
    /// Interface for the query service
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.IService" />
    public interface IQueryService : IService
    {
        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns></returns>
        FilterDefinition<T> BuildQuery<T, O>() where O : class, T, new();

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="advancedSearchModel">The advanced search model</param>
        /// <returns></returns>
        FilterDefinition<T> BuildQuery<T, O>(AdvancedSearchModel<O> advancedSearchModel) where O : class, T, new();
    }
}
