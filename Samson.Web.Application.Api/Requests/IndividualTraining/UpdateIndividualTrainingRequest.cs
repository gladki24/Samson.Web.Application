using System;
namespace Samson.Web.Application.Api.Requests.IndividualTraining
{
    /// <summary>
    /// Request to update IndividualTraining.
    /// </summary>
    public class UpdateIndividualTrainingRequest
    {
        public string IndividualTrainingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GymObjectId { get; set; }
    }
}
