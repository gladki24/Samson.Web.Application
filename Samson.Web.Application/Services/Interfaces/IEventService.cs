using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.Event;
using System.Threading.Tasks;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Services to work with Event domain.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Create Event domain.
        /// </summary>
        /// <param name="dataStructure">Data to create Event domain</param>
        /// <returns>Event Id</returns>
        Task<ObjectId> Create(CreateEventDataStructure dataStructure);

        /// <summary>
        /// Update Event domain.
        /// </summary>
        /// <param name="dataStructure">Data to update Event domain</param>
        /// <returns>Event Id</returns>
        Task<ObjectId> Update(UpdateEventDataStructure dataStructure);

        /// <summary>
        /// Delete Event domain.
        /// </summary>
        /// <param name="id">Id of Event</param>
        /// <returns>Event Id</returns>
        Task<ObjectId> Delete(ObjectId id);
    }
}
