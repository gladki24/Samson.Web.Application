using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.IndividualTraining
{
    /// <summary>
    /// Command to confirm open training by IndividualTrainer.
    /// </summary>
    public class ConfirmIndividualTrainingCommand : IRequest<ObjectId>
    {
        public string IndividualTrainingId { get; set; }
    }
}
