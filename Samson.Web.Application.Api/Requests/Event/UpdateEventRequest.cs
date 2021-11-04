﻿namespace Samson.Web.Application.Api.Requests.Event
{
    public class UpdateEventRequest
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int MaximumParticipants { get; set; }
        public string EventSupervisorId { get; set; }
        public string GymRoomId { get; set; }
    }
}