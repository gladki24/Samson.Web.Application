using System;
using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.GymObject
{
    /// <summary>
    /// Command to add GymRoom.
    /// </summary>
    public class AddGymRoomCommand : IRequest<ObjectId>
    {
        public string GymObjectId { get; set; }
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
