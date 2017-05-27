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
        /// <typeparam name="TInterface">The interface type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns></returns>
        FilterDefinition<TInterface> BuildQuery<TInterface, TModel>() where TModel : class, TInterface, new();

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <typeparam name="TInterface">The interface type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="searchModel">The search model</param>
        /// <returns></returns>
        FilterDefinition<TInterface> BuildQuery<TInterface, TModel>(TModel searchModel) where TModel : class, TInterface, new();
    }
}
