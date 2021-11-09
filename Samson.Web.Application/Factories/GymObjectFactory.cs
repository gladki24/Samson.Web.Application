using System.Collections.Generic;
using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    [Factory]
    public class GymObjectFactory : IGymObjectFactory
    {
        public GymObject CreateGymObject(CreateGymObjectDataStructure dataStructure) => new GymObject(
                ObjectId.GenerateNewId(),
                dataStructure.Name,
                CreateCovidConfiguration(dataStructure.CovidConfiguration),
                CreateRooms(dataStructure.Rooms)
                );

        public GymRoom CreateGymRoom(AddGymRoomDataStructure dataStructure) =>
            new GymRoom(ObjectId.GenerateNewId(), dataStructure.Name, dataStructure.Dimensions);

        private CovidConfiguration CreateCovidConfiguration(
            CovidConfigurationDataStructure covidConfigurationDataStructure) => new CovidConfiguration(ObjectId.GenerateNewId(),
                covidConfigurationDataStructure.PersonFactorPerMeter, covidConfigurationDataStructure.IsActive);

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
