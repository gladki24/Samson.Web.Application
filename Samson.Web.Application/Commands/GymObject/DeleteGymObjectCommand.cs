using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.GymObject
{
    /// <summary>
    /// Command to delete gym object
    /// </summary>
    public class DeleteGymObjectCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
    }
}
