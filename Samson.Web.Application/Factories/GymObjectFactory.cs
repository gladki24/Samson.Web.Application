using System.Collections.Generic;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create GymObject related models.
    /// </summary>
    [Factory]
    public class GymObjectFactory : IGymObjectFactory
    {
        /// <summary>
        /// Create GymObject model with id generation.
        /// </summary>
        /// <param name="dataStructure">Information about gym objecet</param>
        /// <returns>Representation of GymObject</returns>
        public GymObject CreateGymObject(CreateGymObjectDataStructure dataStructure) => new GymObject(
                ObjectId.GenerateNewId(),
                dataStructure.Name,
                CreateCovidConfiguration(dataStructure.CovidConfiguration),
                CreateRooms(dataStructure.Rooms)
                );

        /// <summary>
        /// Create GymRoom model with id generation
        /// </summary>
        /// <param name="dataStructure">Information about gym room to create</param>
        /// <returns>Representation of GymRoom</returns>
        public GymRoom CreateGymRoom(AddGymRoomDataStructure dataStructure) =>
            new GymRoom(ObjectId.GenerateNewId(), dataStructure.Name, dataStructure.Dimensions);

        /// <summary>
        /// Create CovidConfiguration with id generation
        /// </summary>
        /// <param name="covidConfigurationDataStructure">Information about covid configuration to create</param>
        /// <returns>CovidConfiguration</returns>
        private CovidConfiguration CreateCovidConfiguration(
            CovidConfigurationDataStructure covidConfigurationDataStructure) => new CovidConfiguration(ObjectId.GenerateNewId(),
                covidConfigurationDataStructure.PersonFactorPerMeter, covidConfigurationDataStructure.IsActive);

        /// <summary>
        /// Create list of gym rooms.
        /// </summary>
        /// <param name="dataStructures">Information about rooms to create</param>
        /// <returns>List of GymRooms</returns>
        private IList<GymRoom> CreateRooms(IEnumerable<RoomConfigurationDataStructure> dataStructures)
        {
            var gymRooms = new List<GymRoom>();

            foreach (var roomConfigurationDataStructure in dataStructures)
            {
                gymRooms.Add(new GymRoom(
                    ObjectId.GenerateNewId(), 
                    roomConfigurationDataStructure.Name,
                    roomConfigurationDataStructure.Dimensions
                    ));
            }

            return gymRooms;
        }
    }
}
