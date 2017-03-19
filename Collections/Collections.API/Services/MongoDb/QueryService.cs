using Collections.API.Helpers;
using Collections.API.Models;
using Collections.API.Services.Interfaces.MongoDb;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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
        /// <typeparam name="TInterface">The interface type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <returns></returns>
        public FilterDefinition<TInterface> BuildQuery<TInterface, TModel>() where TModel : class, TInterface, new()
        {
            return null;
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <typeparam name="TInterface">The interface type</typeparam>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <param name="advancedSearchModel">The advanced search model</param>
        /// <returns></returns>
        public FilterDefinition<TInterface> BuildQuery<TInterface, TModel>(AdvancedSearchModel<TModel> advancedSearchModel) where TModel : class, TInterface, new()
        {
            var includedFields = advancedSearchModel.IncludedFields.ToValueDictionary();
            var excludedFields = advancedSearchModel.ExcludedFields.ToValueDictionary();

            var builder = Builders<TInterface>.Filter;

            var incFilter = builder.Empty;
            var excFilter = builder.Empty;

            foreach (var incField in includedFields.ToList())
            {
                Type valueType = incField.Value.GetType();

                if (valueType == typeof(DateTime))
                {
                    var startDate = new DateTime(((DateTime)incField.Value).Year, 1, 1);
                    var endDate = new DateTime(startDate.AddYears(1).Year, 1, 1);

                    incFilter |= builder.Gte(incField.Key, startDate) & builder.Lt(incField.Key, endDate);
                }

                if (incField.Key.Contains("["))
                {
                    var newKey = incField.Key.Remove(incField.Key.Length - 3);

                    excFilter |= builder.AnyNe(newKey, incField.Value);
                }

                incFilter |= builder.Eq(incField.Key, incField.Value);
            }

            foreach (var excField in excludedFields.ToList())
            {
                Type valueType = excField.Value.GetType();

                if (valueType == typeof(DateTime))
                {
                    var startDate = new DateTime(((DateTime)excField.Value).Year, 1, 1);
                    var endDate = new DateTime(startDate.AddYears(1).Year, 1, 1);

                    incFilter |= builder.Gte(excField.Key, startDate) & builder.Lt(excField.Key, endDate);
                }

                if (excField.Key.Contains("["))
                {
                    var newKey = excField.Key.Remove(excField.Key.Length - 3);

                    excFilter |= builder.AnyNe(newKey, excField.Value);
                }

                excFilter &= builder.Ne(excField.Key, excField.Value);
            }

            return incFilter & excFilter;
        }
    }
}