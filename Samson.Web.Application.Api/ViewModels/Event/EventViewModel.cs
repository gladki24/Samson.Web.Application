using System;
using System.Collections.Generic;

namespace Samson.Web.Application.Api.ViewModels.Event
{
    /// <summary>
    /// Event view model.
    /// </summary>
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public IEnumerable<string> ParticipantsId { get; set; }
        public string EventSupervisorId { get; set; }
        public string GymRoomId { get; set; }
    }
}
