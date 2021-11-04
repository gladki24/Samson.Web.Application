using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.Event;
using System;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent event in gym object
    /// </summary>
    public class Event : IAggregateRoot
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipanats { get; set; }
        public ObjectId[] ParticipantsId { get; set; }
        public ObjectId EventSupervisorId { get; set; }
        public ObjectId GymRoomId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Data structure to create Event</param>
        public Event(ObjectId id, CreateEventDataStructure dataStructure)
        {
            Id = id;
            Name = dataStructure.Name;
            StartDate = dataStructure.StartDate;
            EndDate = dataStructure.EndDate;
            MaximumParticipanats = dataStructure.MaximumParticipants;
            ParticipantsId = dataStructure.Participants;
            EventSupervisorId = dataStructure.EventSupervisor;
            GymRoomId = dataStructure.GymRoomId;
        }

        /// <summary>
        /// Update model by data structure
        /// </summary>
        /// <param name="dataStructure">Data structure of Event domain</param>
        public void Update(UpdateEventDataStructure dataStructure)
        {
            Name = dataStructure.Name;
            StartDate = dataStructure.StartDate;
            EndDate = dataStructure.EndDate;
            MaximumParticipanats = dataStructure.MaximumParticipants;
            EventSupervisorId = dataStructure.EventSupervisor;
            GymRoomId = dataStructure.GymRoomId;
        }
    }
}
