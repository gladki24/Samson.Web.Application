using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.GymObject;

namespace Samson.Web.Application.Commands.GymObject
{
    /// <summary>
    /// Command to update existing gym object
    /// </summary>
    public class UpdateGymObjectCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CovidConfigurationDataStructure CovidConfiguration { get; set; }
    }
}
