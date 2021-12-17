using System;
using MongoDB.Bson;
using NUnit.Framework;
using Samson.Web.Application.Infrastructure.Exceptions;
using Samson.Web.Application.Models.DataStructures.IndividualTraining;
using Samson.Web.Application.Models.Domains;
using Samson.Web.Application.Models.Enums;

namespace Samson.Web.Application.UnitTests
{
    /// <summary>
    /// Tests of IndividualTraining model
    /// </summary>
    [TestFixture]
    public class IndividualTrainingUnitTest
    {
        private IndividualTraining _individualTraining;

        /// <summary>
        /// Initialization of IndividualTraining tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var endDate = DateTime.Today;
            endDate = endDate.AddHours(3);

            _individualTraining = new IndividualTraining(ObjectId.GenerateNewId(),
                new CreateIndividualTrainingDataStructure
                {
                    ClientId = null,
                    EndDate = endDate,
                    StartDate = DateTime.Today,
                    GymObjectId = ObjectId.Empty,
                    PersonalTrainerId = ObjectId.Empty,
                    Type = IndividualTrainingType.Open
                });
        }

        /// <summary>
        /// IndividualTraining can be cancelled
        /// </summary>
        [Test]
        public void IndividualTraining_CancelTraining()
        {
            _individualTraining.Cancel();
            Assert.AreEqual(_individualTraining.Type, IndividualTrainingType.Cancelled, "Training has possibility to be cancelled");
        }

        /// <summary>
        /// User can enroll
        /// </summary>
        [Test]
        public void IndividualTraining_UserCanEnroll()
        {
            _individualTraining.Enroll(ObjectId.GenerateNewId());
            Assert.AreEqual(_individualTraining.Type, IndividualTrainingType.Pending, "Training is pending if has enrolled user");
            Assert.NotNull(_individualTraining.ClientId, "Individual training has information about enrolled user");
        }

        /// <summary>
        /// IndividualTraining can be confirmed if is Pending type
        /// </summary>
        [Test]
        public void IndividualTraining_ConfirmTraining()
        {
            _individualTraining.Enroll(ObjectId.GenerateNewId());

            _individualTraining.Confirm();
            Assert.AreEqual(_individualTraining.Type, IndividualTrainingType.Confirmed, "Training has possibility to be confirmed");
        }

        /// <summary>
        /// User cannot be enrolled if no information about client id
        /// </summary>
        [Test]
        public void IndividualTraining_ThrowIfDuringEnrollNoInformationAboutClient()
        {
            Assert.Throws<BusinessLogicException>(() => _individualTraining.Enroll(ObjectId.Empty), "Invalid training status");
        }

        /// <summary>
        /// Individual training can be confirmed only if is pending
        /// </summary>
        [Test]
        public void IndividualTraining_ThrowIfTryConfirmNotPendingTraining()
        {
            Assert.Throws<BusinessLogicException>(() => _individualTraining.Confirm(), "Invalid training status");
        }

        /// <summary>
        /// Invalid EndDate should throw exception while construct
        /// </summary>
        [Test]
        public void IndividualTraining_InvalidEndDateThrowException()
        {
            var today = DateTime.Now;
            var nextWeek = today.AddDays(7);

            Assert.Throws<BusinessLogicException>(() => _individualTraining.Update(
                new UpdateIndividualTrainingDataStructure
                {
                    EndDate = today,
                    StartDate = nextWeek,
                    GymObjectId = ObjectId.GenerateNewId(),
                    IndividualTrainingId = ObjectId.GenerateNewId()
                }), "Invalid end date. Start date should be earlier than end date");
        }
    }
}
