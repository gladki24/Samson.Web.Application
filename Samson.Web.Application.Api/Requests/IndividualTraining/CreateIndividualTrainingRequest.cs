using System;

namespace Samson.Web.Application.Api.Requests.IndividualTraining
{
    /// <summary>
    /// Request to create new IndividualTraining.
    /// </summary>
    public class CreateIndividualTrainingRequest
    {
        public string PersonalTrainerId { get; set; }
        public string ClientId { get; set; }
        public string GymObjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
