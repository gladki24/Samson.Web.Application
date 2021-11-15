namespace Samson.Web.Application.Api.Requests.IndividualTraining
{
    /// <summary>
    /// Request to enroll Client in IndividualTraining.
    /// </summary>
    public class EnrollIndividualTrainingRequest
    {
        public string IndividualTrainingId { get; set; }
        public string ClientId { get; set; }
    }
}
