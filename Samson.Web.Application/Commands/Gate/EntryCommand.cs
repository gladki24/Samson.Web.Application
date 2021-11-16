using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.Gate
{
    /// <summary>
    /// Command to inform about client entry to gym.
    /// </summary>
    public class EntryCommand : IRequest<ObjectId>
    {
        public string GymObjectId { get; set; }
        public string ClientId { get; set; }
    }
}
