using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymObject;

namespace Samson.Web.Application.Queries.GymObject
{
    public class GetGymRoomByIdQuery : IRequest<GymRoomDetailsDto>
    {
        public ObjectId Id { get; set; }
    }
}
