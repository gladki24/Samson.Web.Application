using System;
using System.Collections.Generic;

namespace Samson.Web.Application.Api.ViewModels.Event
{
    /// <summary>
    /// Event view model
    /// </summary>
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaximumPartipicants { get; set; }
        public IEnumerable<string> ParipicantIds { get; set; }
        public string EventSupervisorId { get; set; }
        public string GymRoomId { get; set; }
    }
}
