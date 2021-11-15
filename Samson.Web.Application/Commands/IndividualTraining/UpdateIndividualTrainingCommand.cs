using System;
using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.IndividualTraining
{
    /// <summary>
    /// Command to update IndividualTraining.
    /// </summary>
    public class UpdateIndividualTrainingCommand : IRequest<ObjectId>
    {
        public string IndividualTrainingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GymObjectId { get; set; }
    }
}
