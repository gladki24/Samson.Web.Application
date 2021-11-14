using System;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.Subscription
{
    public class SubscriptionDto
    {
        public ObjectId Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ObjectId GymPassTypeId { get; set; }
    }
}
