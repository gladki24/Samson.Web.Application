using System;
using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.IndividualTraining
{
    /// <summary>
    /// Command to create new IndividualTraining.
    /// </summary>
    public class CreateIndividualTrainingCommand : IRequest<ObjectId>
    {
        public string PersonalTrainerId { get; set; }
        public string ClientId { get; set; }
        public string GymObjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
