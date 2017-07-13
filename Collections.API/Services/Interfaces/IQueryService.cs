using MongoDB.Driver;

namespace Collections.API.Services.Interfaces
{
    /// <summary>
    /// Interface for the query service
    /// </summary>
    public interface IQueryService
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
