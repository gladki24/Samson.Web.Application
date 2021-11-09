using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.GymObject
{
    /// <summary>
    /// Command to remove GymRoom
    /// </summary>
    public class RemoveGymRoomCommand : IRequest<ObjectId>
    {
        public string GymObjectId { get; set; }
        public string GymRoomId { get; set; }
    }
}
