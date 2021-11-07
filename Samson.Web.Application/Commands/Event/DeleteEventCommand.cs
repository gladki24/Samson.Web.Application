using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.Event
{
    /// <summary>
    /// Command to delete Event
    /// </summary>
    public class DeleteEventCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
    }
}
