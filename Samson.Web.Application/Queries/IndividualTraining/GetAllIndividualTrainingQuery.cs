using System.Collections.Generic;
using MediatR;
using Samson.Web.Application.Models.Dtos.IndividualTraining;

namespace Samson.Web.Application.Queries.IndividualTraining
{
    /// <summary>
    /// Query to get all IndividualTraining view models.
    /// </summary>
    public class GetAllIndividualTrainingQuery : IRequest<List<IndividualTrainingDto>>
    {
    }
}
