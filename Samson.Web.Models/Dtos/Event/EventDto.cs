using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.Event
{
    /// <summary>
    /// Event data transfer object.
    /// </summary>
    public class EventDto
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public IEnumerable<ObjectId> ParticipantsId { get; set; }
        public ObjectId EventSupervisorId { get; set; }
        public ObjectId GymRoomId { get; set; }
    }
}
