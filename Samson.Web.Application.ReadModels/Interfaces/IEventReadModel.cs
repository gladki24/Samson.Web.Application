using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.Event;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get Event dtos.
    /// </summary>
    public interface IEventReadModel
    {
        /// <summary>
        /// Get Event from collection by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EventDto> GetById(ObjectId id);

        /// <summary>
        /// Get all Events from collection.
        /// </summary>
        /// <returns></returns>
        Task<List<EventDto>> GetAll();
    }
}
