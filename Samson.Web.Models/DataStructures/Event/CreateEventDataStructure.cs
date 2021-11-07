using MongoDB.Bson;
using System;

namespace Samson.Web.Application.Models.DataStructures.Event
{
    /// <summary>
    /// Data structure to create Event.
    /// </summary>
    public class CreateEventDataStructure
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public ObjectId[] Participants { get; set; }
        public ObjectId EventSupervisor { get; set; }
        public ObjectId GymRoomId { get; set; }
    }
}
