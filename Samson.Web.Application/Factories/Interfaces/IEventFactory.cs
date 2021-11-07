﻿using Samson.Web.Application.Models.DataStructures.Event;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory  to create Event domain
    /// </summary>
    public interface IEventFactory
    {
        /// <summary>
        /// Create event from data structure
        /// </summary>
        /// <param name="dataStructure">Data structure to create event</param>
        /// <returns>Event domain</returns>
        Event CreateEvent(CreateEventDataStructure dataStructure);
    }
}
