using System;
using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Models.DataStructures.IndividualTraining;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent prepared by PersonalTrainer IndividualTraining  with Client.
    /// </summary>
    public class IndividualTraining : IAggregate
    {
        public ObjectId Id { get; private set; }
        public ObjectId PersonalTrainerId { get; private set; }
        public ObjectId? ClientId { get; private set; }
        public ObjectId GymObjectId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public IndividualTrainingType Type { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Data structure to create IndividualTraining</param>
        public IndividualTraining(ObjectId id, CreateIndividualTrainingDataStructure dataStructure)
        {
            Id = id;
            PersonalTrainerId = dataStructure.PersonalTrainerId;
            ClientId = dataStructure.ClientId;
            GymObjectId = dataStructure.GymObjectId;
            StartDate = dataStructure.StartDate;
            EndDate = dataStructure.EndDate;
            Type = dataStructure.Type;
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public IndividualTraining()
        {
        }

        /// <summary>
        /// Update individual training.
        /// </summary>
        /// <param name="dataStructure"></param>
        public void Update(UpdateIndividualTrainingDataStructure dataStructure)
        {
            GymObjectId = dataStructure.GymObjectId;
            StartDate = dataStructure.StartDate;
            EndDate = dataStructure.EndDate;
        }

        /// <summary>
        /// Enroll client in individual training.
        /// </summary>
        /// <param name="dataStructure">Information about client id</param>
        public void Enroll(EnrollInIndividualTrainingDataStructure dataStructure)
        {
            if (dataStructure.ClientId == null)
                throw new BusinessLogicException("ClientId is obligatory to enroll");

            ClientId = dataStructure.ClientId;
            Type = IndividualTrainingType.Pending;
        }

        /// <summary>
        /// Confirm pending training.
        /// </summary>
        public void Confirm()
        {
            if (Type != IndividualTrainingType.Pending)
                throw new BusinessLogicException(
                    "Invalid training type. Individual training should be pending to be confirmed.");
            if (ClientId == null)
                throw new BusinessLogicException("Individual training must contains information about client.");

            Type = IndividualTrainingType.Confirmed;
        }

        /// <summary>
        /// Cancel individual training.
        /// </summary>
        public void Cancel()
        {
            if (Type != IndividualTrainingType.Cancelled)
                throw new BusinessLogicException("Training is already cancelled.");

            Type = IndividualTrainingType.Cancelled;
        }
    }
}