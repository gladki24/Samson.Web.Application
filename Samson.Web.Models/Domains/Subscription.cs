using System;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent actual active client gym pass subscription.
    /// </summary>
    public class Subscription : IAggregate
    {
        public ObjectId Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public ObjectId GymPassTypeId { get; private set; }

        public bool IsActive => DateTime.Compare(EndDate, DateTime.Now) > 0;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="startDate">Since when the pass is valid</param>
        /// <param name="endDate">Date until which the pass is valid</param>
        /// <param name="gymPassTypeId">Gym pass type</param>
        public Subscription(ObjectId id, DateTime startDate, DateTime endDate, ObjectId gymPassTypeId)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            GymPassTypeId = gymPassTypeId;
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Subscription()
        {
        }

        /// <summary>
        /// Extend
        /// </summary>
        /// <param name="gymPass"></param>
        public void Extend(GymPassType gymPass)
        {
            GymPassTypeId = gymPass.Id;

            if (IsActive)
            {
                EndDate = EndDate.AddDays(gymPass.Duration);
            }
            else
            {
                StartDate = DateTime.Now;
                EndDate = DateTime.Now.AddDays(gymPass.Duration);
            }
        }
    }
}
