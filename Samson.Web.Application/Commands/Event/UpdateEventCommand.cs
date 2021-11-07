using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.Event
{
    /// <summary>
    /// Command to update Event
    /// </summary>
    public class UpdateEventCommand : IRequest<ObjectId>
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public string EventSupervisorId { get; set; }
        public string GymRoomId { get; set; }
    }
}
