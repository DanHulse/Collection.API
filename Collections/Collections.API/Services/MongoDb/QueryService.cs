using Collections.API.Models;
using Collections.API.Services.Interfaces.MongoDb;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collections.API.Services.MongoDb
{
    /// <summary>
    /// Service for building queries for the MongoDb API
    /// </summary>
    /// <seealso cref="Collections.API.Services.Interfaces.MongoDb.IQueryService" />
    public class QueryService : IQueryService
    {
        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <returns></returns>
        public FilterDefinition<T> BuildQuery<T, O>() where O : class, T, new()
        {
            return null;
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="O">The model type</typeparam>
        /// <param name="advancedSearchModel">The advanced search model</param>
        /// <returns></returns>
        public FilterDefinition<T> BuildQuery<T, O>(AdvancedSearchModel<O> advancedSearchModel) where O : class, T, new()
        {
            return null;
        }
    }
}