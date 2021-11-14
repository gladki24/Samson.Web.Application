using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.Event;
using System;
using System.Collections.Generic;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent Event in gym object.
    /// </summary>
    public class Event : IAggregateRoot
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public IList<ObjectId> ParticipantsId { get; set; }
        public ObjectId EventSupervisorId { get; set; }
        public ObjectId GymRoomId { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Data structure to create Event</param>
        public Event(ObjectId id, CreateEventDataStructure dataStructure)
        {
            Id = id;
            Name = dataStructure.Name;
            StartDate = dataStructure.StartDate;
            EndDate = dataStructure.EndDate;
            MaximumParticipants = dataStructure.MaximumParticipants;
            ParticipantsId = dataStructure.ParticipantsId;
            EventSupervisorId = dataStructure.EventSupervisorId;
            GymRoomId = dataStructure.GymRoomId;
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Event()
        {}

        /// <summary>
        /// Update model by data structure
        /// </summary>
        /// <param name="dataStructure">Data structure of Event domain</param>
        public void Update(UpdateEventDataStructure dataStructure)
        {
            Name = dataStructure.Name;
            StartDate = dataStructure.StartDate;
            EndDate = dataStructure.EndDate;
            MaximumParticipants = dataStructure.MaximumParticipants;
            EventSupervisorId = dataStructure.EventSupervisor;
            GymRoomId = dataStructure.GymRoomId;
        }
    }
}
