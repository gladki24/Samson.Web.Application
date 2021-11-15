using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.IndividualTraining
{
    /// <summary>
    /// Command to cancel IndividualTraning.
    /// </summary>
    public class CancelIndividualTrainingCommand : IRequest<ObjectId>
    {
        public string IndividualTrainingId { get; set; }
    }
}
