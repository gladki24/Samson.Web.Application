using MongoDB.Bson;
using System;

namespace Samson.Web.Application.Models.DataStructures.Event
{
    /// <summary>
    /// Data structure to update existing Event.
    /// </summary>
    public class UpdateEventDataStructure
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public ObjectId EventSupervisor { get; set; }
        public ObjectId GymRoomId { get; set; }
    }
}
