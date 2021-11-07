using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures;
using Samson.Web.Application.Models.DataStructures.GymObject;

namespace Samson.Web.Application.Commands.GymObject
{
    /// <summary>
    /// Command to create new gym object
    /// </summary>
    public class CreateGymObjectCommand : IRequest<ObjectId>
    {
        public string Name { get; set; }
        public CovidConfigurationDataStructure CovidConfiguration { get; set; }
        public IEnumerable<RoomConfigurationDataStructure> Rooms { get; set; }
    }
}
