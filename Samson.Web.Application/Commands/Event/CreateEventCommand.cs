using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.Event
{
    /// <summary>
    /// Command to create Event
    /// </summary>
    public class CreateEventCommand : IRequest<ObjectId>
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public string[] ParticipantsId { get; set; }
        public string EventSupervisorId { get; set; }
        public string GymRoomId { get; set; }
    }
}
