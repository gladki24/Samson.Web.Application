using System;

namespace Samson.Web.Application.Models.Dtos.IndividualTraining
{
    /// <summary>
    /// IndividualTraining dtos.
    /// </summary>
    public class IndividualTrainingDto
    {
        public string Id { get; set; }
        public string PersonalTrainerId { get; set; }
        public string ClientId { get; set; }
        public string GymObjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Type { get; set; }
    }
}
