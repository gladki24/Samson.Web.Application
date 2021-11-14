using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Samson.Web.Application.Infrastructure.Configuration;

namespace Samson.Web.Application.Infrastructure.Repository
{
    /// <summary>
    /// Generic MongoDB implementation of IRepository to communicate with data source
    /// </summary>
    /// <typeparam name="TModel">Type of model mapped to entity in MongoDB collection</typeparam>
    /// <typeparam name="TEntity">Type of entity stored in MongoDB collection</typeparam>
    public abstract class MongoRepository<TModel, TEntity> : IRepository<TModel> where TModel : IAggregateRoot where TEntity : IEntity
    {
        protected readonly IMongoCollection<TEntity> Collection;
        protected readonly IMapper Mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with MongoDB database</param>
        /// <param name="mapper">AutoMapper to map from model to entity</param>
        public MongoRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            var client = new MongoClient(databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(databaseConfiguration.DatabaseName);

            Collection = database.GetCollection<TEntity>($"{typeof(TModel).Name}Collection");
        }

        /// <summary>
        /// Constructor with possibility to specify custom collection name.
        /// </summary>
        /// <param name="databaseConfiguration">Configuration of connection with MongoDB database</param>
        /// <param name="mapper">AutoMapper to map from model to entity</param>
        /// <param name="collectionName">Allow to specify custom collection name</param>
        public MongoRepository(IDatabaseConfiguration databaseConfiguration, IMapper mapper, string collectionName)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            var client = new MongoClient(databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(databaseConfiguration.DatabaseName);

            Collection = database.GetCollection<TEntity>(collectionName);
        }

        /// <summary>
        /// Get model by id
        /// </summary>
        /// <param name="id">Id of the document stored in collection</param>
        /// <returns>Model from collection</returns>
        public TModel Get(ObjectId id)
        {
            var entity = Collection.Find(model => model.Id == id).FirstOrDefault();
            return Mapper.Map<TEntity, TModel>(entity);
        }

        /// <summary>
        /// Get all models stored in collection
        /// </summary>
        /// <returns>List of all models stored in collection</returns>
        public List<TModel> Get()
        {
            var entities = Collection.Find(model => true).ToList();
            return Mapper.Map<List<TEntity>, List<TModel>>(entities);
        }

        /// <summary>
        /// Add model to collection
        /// </summary>
        /// <param name="model">Model to add to collection</param>
        /// <returns>Key of created entity in collection</returns>
        public Task<ObjectId> Create(TModel model)
        {
            var entity = Mapper.Map<TModel, TEntity>(model);
            var result = Collection.InsertOneAsync(entity).ContinueWith(_ => model.Id);
            return result;
        }

        /// <summary>
        /// Update model in collection find by model id
        /// </summary>
        /// <param name="id">Id of model to update</param>
        /// <param name="updatedModel">Updated model to persist in collection</param>
        /// <returns>Key of updated entity in collection</returns>
        public Task<ObjectId> Update(ObjectId id, TModel updatedModel)
        {
            var entity = Mapper.Map<TModel, TEntity>(updatedModel);
            return Collection.ReplaceOneAsync(model => model.Id == id, entity).ContinueWith(_ => updatedModel.Id);
        }

        /// <summary>
        /// Remove model from data source by entire model
        /// </summary>
        /// <param name="modelToDelete">Entire model to find object in collection</param>
        /// <returns>Key of removed entity in collection</returns>
        public Task<ObjectId> Remove(TModel modelToDelete)
        {
            var entity = Mapper.Map<TModel, TEntity>(modelToDelete);
            return Collection.DeleteOneAsync(model => model.Id == entity.Id).ContinueWith(_ => modelToDelete.Id);
        }

        /// <summary>
        /// Remove model from collection by model id
        /// </summary>
        /// <param name="id">Id model to find object in collection</param>
        /// <returns>Key of removed entity in collection</returns>
        public Task<ObjectId> Remove(ObjectId id)
            => Collection.DeleteOneAsync(model => model.Id == id).ContinueWith(_ => id);
    }
}
