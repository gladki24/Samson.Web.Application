using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.GymPass
{
    /// <summary>
    /// Command to delete GymPassType
    /// </summary>
    public class DeleteGymPassTypeCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
    }
}
