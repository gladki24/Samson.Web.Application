using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.IndividualTraining
{
    /// <summary>
    /// Command to enroll Client in IndividualTraining.
    /// </summary>
    public class EnrollIndividualTrainingCommand : IRequest<ObjectId>
    {
        public string IndividualTrainingId { get; set; }
        public string ClientId { get; set; }
    }
}
