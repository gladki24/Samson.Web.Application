using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Samson.Web.Application.Infrastructure.Attributes;

namespace Samson.Web.Application.Infrastructure.Repository
{
    /// <summary>
    /// Generic MongoDB implementation of IRepository to communicate with data source
    /// </summary>
    /// <typeparam name="TModel">Type of model stored in MongoDB collection</typeparam>
    public abstract class MongoRepository<TModel> : IRepository<TModel> where TModel : IAggregateRoot
    {
        protected readonly IMongoCollection<TModel> Collection;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with MongoDB database</param>
        public MongoRepository(IDatabaseConfiguration databaseConfiguration)
        {
            var client = new MongoClient(databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(databaseConfiguration.DatabaseName);

            Collection = database.GetCollection<TModel>($"{nameof(TModel)}Collection");
        }

        /// <summary>
        /// Get model by id
        /// </summary>
        /// <param name="id">Id of the document stored in collection</param>
        /// <returns>Model from collection</returns>
        public TModel Get(ObjectId id)
            => Collection.Find(model
                => model.Id == id).FirstOrDefault();

        /// <summary>
        /// Get all models stored in collection
        /// </summary>
        /// <returns>List of all models stored in collection</returns>
        public List<TModel> Get()
            => Collection.Find(model => true).ToList();

        /// <summary>
        /// Add model to collection
        /// </summary>
        /// <param name="model">Model to add to collection</param>
        /// <returns>Reference to model inserted to collection</returns>
        public TModel Create(TModel model)
        {
            Collection.InsertOne(model);
            return model;
        }

        /// <summary>
        /// Update model in collection find by model id
        /// </summary>
        /// <param name="id">Id of model to update</param>
        /// <param name="updatedModel">Updated model to persist in collection</param>
        public void Update(ObjectId id, TModel updatedModel)
            => Collection.ReplaceOne(model => model.Id == id, updatedModel);

        /// <summary>
        /// Remove model from data source by entire model
        /// </summary>
        /// <param name="modelToDelete">Entire model to find object in collection</param>
        public void Remove(TModel modelToDelete)
            => Collection.DeleteOne(model => model.Id == modelToDelete.Id);

        /// <summary>
        /// Remove model from collection by model id
        /// </summary>
        /// <param name="id">Id model to find object in collection</param>
        public void Remove(ObjectId id)
            => Collection.DeleteOne(model => model.Id == id);
    }
}
