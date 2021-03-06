using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Samson.Web.Application.Infrastructure.Repository
{
    /// <summary>
    /// Generic Repository to communicate with data source
    /// </summary>
    /// <typeparam name="TModel">Type of model mapped to entity in data source</typeparam>
    public interface IRepository<TModel> where TModel : IAggregate
    {
        /// <summary>
        /// Get model by id
        /// </summary>
        /// <param name="id">Id of the document in database</param>
        /// <returns>Model from data source</returns>
        public TModel Get(ObjectId id);

        /// <summary>
        /// Get all models stored in data source
        /// </summary>
        /// <returns>List of all models stored in data source</returns>
        public List<TModel> Get();

        /// <summary>
        /// Add model to data source
        /// </summary>
        /// <param name="model">Model data structure</param>
        /// <returns>Key of created entity in data source</returns>
        public Task<ObjectId> Create(TModel model);

        /// <summary>
        /// Update model in data source find by model id
        /// </summary>
        /// <param name="id">Id of model to update</param>
        /// <param name="model">Updated data to persist in data source</param>
        /// <returns>Key of updated entity in data source</returns>
        public Task<ObjectId> Update(ObjectId id, TModel model);

        /// <summary>
        /// Remove model from data source by entire model
        /// </summary>
        /// <param name="model">Entire model to find object in data source</param>
        /// <returns>Key of removed entity in data source</returns>
        public Task<ObjectId> Remove(TModel model);

        /// <summary>
        /// Remove mode from data source by model id
        /// </summary>
        /// <param name="id">Id of model to find object in data source</param>
        /// <returns>Key of removed entity in data source</returns>
        public Task<ObjectId> Remove(ObjectId id);
    }
}
