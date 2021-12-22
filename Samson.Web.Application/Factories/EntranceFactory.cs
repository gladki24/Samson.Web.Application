using System;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.Gym;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create Entrance model
    /// </summary>
    [Factory]
    public class EntranceFactory : IEntranceFactory
    {
        /// <summary>
        /// Create entrance information with id generation
        /// </summary>
        /// <param name="dataStructure">Information about entrance</param>
        /// <returns>Entrance</returns>
        public Entrance Create(EntryDataStructure dataStructure)
            => new Entrance(ObjectId.GenerateNewId(), dataStructure, DateTime.Now);
    }
}
