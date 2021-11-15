using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.IndividualTraining;

namespace Samson.Web.Application.Queries.IndividualTraining
{
    /// <summary>
    /// Query to get IndividualTraining by id.
    /// </summary>
    public class GetIndividualTrainingByIdQuery : IRequest<IndividualTrainingDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        public GetIndividualTrainingByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
