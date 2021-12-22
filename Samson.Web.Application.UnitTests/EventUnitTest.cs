using System;
using MongoDB.Bson;
using NUnit.Framework;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.UnitTests
{
    /// <summary>
    /// Test Event model
    /// </summary>
    [TestFixture]
    public class EventUnitTest
    {
        /// <summary>
        /// Create valid Event
        /// </summary>
        [Test]
        public void Event_CreateValidEvent()
        {
            var today = DateTime.Now;
            var nextWeek = today.AddDays(7);

            var @event = new Event(ObjectId.GenerateNewId(), new CreateEventDataStructure
            {
                MaximumParticipants = 10,
                GymRoomId = ObjectId.GenerateNewId(),
                EventSupervisorId = ObjectId.GenerateNewId(),
                StartDate = today,
                EndDate = nextWeek,
                Name = "TestEvent",
                ParticipantsId = new ObjectId[] {}
            });

            Assert.NotNull(@event);
        }

        /// <summary>
        /// Invalid EndDate should throw exception while construct
        /// </summary>
        [Test] public void Event_ComstructInvalidEndDateThrowException()
        {
            var today = DateTime.Now;
            var nextWeek = today.AddDays(7);

            Assert.Throws<BusinessLogicException>(() =>
                    new Event(ObjectId.GenerateNewId(), new CreateEventDataStructure
                    {
                        MaximumParticipants = 10,
                        GymRoomId = ObjectId.GenerateNewId(),
                        EventSupervisorId = ObjectId.GenerateNewId(),
                        StartDate = nextWeek,
                        EndDate = today,
                        Name = "TestEvent",
                        ParticipantsId = new ObjectId[] { }
                    }),
                "Invalid end date. Start date should be earlier than end date"
            );
        }

        /// <summary>
        /// Invalid EndDate should throw exception while update
        /// </summary>
        [Test]
        public void Event_UpdateInvalidEndDateThrowException()
        {
            var today = DateTime.Now;
            var nextWeek = today.AddDays(7);

            var @event = new Event(ObjectId.GenerateNewId(), new CreateEventDataStructure
            {
                MaximumParticipants = 10,
                GymRoomId = ObjectId.GenerateNewId(),
                EventSupervisorId = ObjectId.GenerateNewId(),
                StartDate = today,
                EndDate = nextWeek,
                Name = "TestEvent",
                ParticipantsId = new ObjectId[] { }
            });

            Assert.Throws<BusinessLogicException>(() =>
                @event.Update(new UpdateEventDataStructure
                {
                    MaximumParticipants = 10,
                    GymRoomId = ObjectId.GenerateNewId(),
                    StartDate = nextWeek,
                    EndDate = today,
                    Name = "TestEvent"
                }),
                "Invalid end date. Start date should be earlier than end date"
            );
        }
    }
}