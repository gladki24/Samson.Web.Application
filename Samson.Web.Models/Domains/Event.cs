using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.Event;
using System;
using System.Collections.Generic;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Models.Resources;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent Event in gym object.
    /// </summary>
    public class Event : IAggregate
    {
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int MaximumParticipants { get; private set; }
        public IList<ObjectId> ParticipantsId { get; private set; }
        public ObjectId EventSupervisorId { get; private set; }
        public ObjectId GymRoomId { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Data structure to create Event</param>
        public Event(ObjectId id, CreateEventDataStructure dataStructure)
        {
            if (dataStructure.StartDate.CompareTo(dataStructure.EndDate) >= 0)
                throw new BusinessLogicException(DomainMessage.EndDateIsEarlierThanStartDate);

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
        {
        }

        /// <summary>
        /// Update model by data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure of Event domain</param>
        public void Update(UpdateEventDataStructure dataStructure)
        {
            if (dataStructure.StartDate.CompareTo(dataStructure.EndDate) >= 0)
                throw new BusinessLogicException(DomainMessage.EndDateIsEarlierThanStartDate);

            Name = dataStructure.Name;
            StartDate = dataStructure.StartDate;
            EndDate = dataStructure.EndDate;
            MaximumParticipants = dataStructure.MaximumParticipants;
            EventSupervisorId = dataStructure.EventSupervisor;
            GymRoomId = dataStructure.GymRoomId;
        }
    }
}