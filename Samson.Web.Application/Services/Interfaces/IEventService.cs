using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.Event;
using System.Threading.Tasks;
using MediatR;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with Event aggregate.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// CreatePersonalTrainer Event aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to create Event domain</param>
        /// <returns>Event Id</returns>
        Task<ObjectId> Create(CreateEventDataStructure dataStructure);

        /// <summary>
        /// Update Event aggregate.
        /// </summary>
        /// <param name="dataStructure">Data to update Event domain</param>
        /// <returns>Event Id</returns>
        Task<ObjectId> Update(UpdateEventDataStructure dataStructure);

        /// <summary>
        /// Delete Event aggregate.
        /// </summary>
        /// <param name="id">Id of Event</param>
        /// <returns>Event Id</returns>
        Task<ObjectId> Delete(ObjectId id);

        /// <summary>
        /// Client for the event.
        /// </summary>
        /// <param name="dataStructure">Data structure to client enroll to event</param>
        /// <returns></returns>
        Task<Unit> ClientEnroll(EnrollEventDataStructure dataStructure);

        /// <summary>
        /// Client resign from participation in the event request.
        /// </summary>
        /// <param name="dataStructure">Data structure to client resign from event</param>
        Task<Unit> ClientResign(ResignEventDataStructure dataStructure);
    }
}
