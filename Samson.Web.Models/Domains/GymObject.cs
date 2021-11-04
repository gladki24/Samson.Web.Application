using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using System.Collections.Generic;
using Samson.Web.Application.Models.DataStructures;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represents gym object of gym network.
    /// </summary>
    public class GymObject : IAggregateRoot
    {
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public CovidConfiguration CovidConfiguration { get; private set; }
        public IEnumerable<GymRoom> Rooms { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="name">Name of object</param>
        /// <param name="covidConfiguration">COVID configuration</param>
        /// <param name="rooms">Rooms located in the building</param>
        public GymObject(ObjectId id, string name, CovidConfiguration covidConfiguration, IEnumerable<GymRoom> rooms)
        {
            Id = id;
            Name = name;
            CovidConfiguration = covidConfiguration;
            Rooms = rooms;
        }

        /// <summary>
        /// Update model by data structure
        /// </summary>
        /// <param name="dataStructure">Data structure of GymObject domain</param>
        public void Update(UpdateGymObjectDataStructure dataStructure)
        {
            Name = dataStructure.Name;
            CovidConfiguration.Update(dataStructure.CovidConfiguration);
        }
    }
}
