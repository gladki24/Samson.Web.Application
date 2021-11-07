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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaximumPartipicants { get; set; }
        public IEnumerable<ObjectId> ParipicantIds { get; set; }
        public ObjectId EventSupervisorId { get; set; }
        public ObjectId GymRoomId { get; set; }
    }
}
