using System;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.Gym;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Aggregate to represent entrance of client to gym
    /// </summary>
    public class Entrance : IAggregate
    {
        public ObjectId Id { get; private set; }
        public ObjectId ClientId { get; private set; }
        public ObjectId GymObjectId { get; private set; }
        public DateTime EntryDate { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Information about client entry</param>
        /// <param name="entryDate">Client entry datetime</param>
        public Entrance(ObjectId id, EntryDataStructure dataStructure, DateTime entryDate)
        {
            Id = id;
            ClientId = dataStructure.ClientId;
            GymObjectId = dataStructure.GymObjectId;
            EntryDate = entryDate;
        }

        /// <summary>
        /// Full arguments constructor
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="clientId">Information about client entry</param>
        /// <param name="gymObjectId">Entry destination</param>
        /// <param name="entryDate">Client entry datetime</param>
        public Entrance(ObjectId id, ObjectId clientId, ObjectId gymObjectId, DateTime entryDate)
        {
            Id = id;
            ClientId = clientId;
            GymObjectId = gymObjectId;
            EntryDate = entryDate;
        }
    }
}
