using System.Collections.Generic;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure.Repository;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Persistence.Repositories.Interfaces
{
    /// <summary>
    /// Aggregate to represent entrance of client to gym
    /// </summary>
    public interface IEntranceRepository : IRepository<Entrance>
    {
        /// <summary>
        /// Get all models by gym object id and client id.
        /// </summary>
        /// <param name="gymObjectId">GymObject id</param>
        /// <param name="clientId">Client id</param>
        /// <returns>Entrance aggregations list</returns>
        public List<Entrance> GetAllByGymObjectIdAndClientId(ObjectId gymObjectId, ObjectId clientId);

        /// <summary>
        /// Get all models by gym object id.
        /// </summary>
        /// <param name="gymObjectId">GymObject id</param>
        /// <returns>Entrance aggregations list</returns>
        public List<Entrance> GetAllByGymObjectId(ObjectId gymObjectId);
    }
}