using System;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Samson.Web.Application.Models.DataStructures.GymObject;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represents gym object of gym network.
    /// </summary>
    public class GymObject : IAggregate
    {
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public CovidConfiguration CovidConfiguration { get; private set; }
        public IList<GymRoom> Rooms { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="name">Name of object</param>
        /// <param name="covidConfiguration">COVID configuration</param>
        /// <param name="rooms">Rooms located in the building</param>
        public GymObject(ObjectId id, string name, CovidConfiguration covidConfiguration, IList<GymRoom> rooms)
        {
            Id = id;
            Name = name;
            CovidConfiguration = covidConfiguration;
            Rooms = rooms;
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public GymObject()
        {
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

        /// <summary>
        /// Calculate gym object area.
        /// </summary>
        /// <returns>Gym object area</returns>
        public int GymObjectArea()
            => Rooms.Aggregate(0, (total, next) => total += next.GetArea());

        /// <summary>
        /// Information about maximum count of clients in gym at the moment.
        /// </summary>
        /// <returns>Maximum client counts in gym at the moment. If the value is -1, it means that there is no limit to the number of clients in the gym.</returns>
        public int CalcMaximumClientsCount()
        {
            if (CovidConfiguration == null)
                return -1;

            var availableGymObjectArea = GymObjectArea();
            return (int) Math.Floor(availableGymObjectArea / CovidConfiguration.PersonFactorPerMeter);
        }
    }
}
