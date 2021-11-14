using MongoDB.Bson;
using System;

namespace Samson.Web.Application.Models.DataStructures.Event
{
    /// <summary>
    /// Data structure to create Event.
    /// </summary>
    public class CreateEventDataStructure
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public ObjectId[] ParticipantsId { get; set; }
        public ObjectId EventSupervisorId { get; set; }
        public ObjectId GymRoomId { get; set; }
    }
}
