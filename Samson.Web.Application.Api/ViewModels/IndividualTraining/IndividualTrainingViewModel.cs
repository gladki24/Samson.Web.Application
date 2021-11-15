using System;

namespace Samson.Web.Application.Api.ViewModels.IndividualTraining
{
    /// <summary>
    /// IndividualTraining view model.
    /// </summary>
    public class IndividualTrainingViewModel
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
