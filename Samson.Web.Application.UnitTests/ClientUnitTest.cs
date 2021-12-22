using System;
using MongoDB.Bson;
using NUnit.Framework;
using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.UnitTests
{
    /// <summary>
    /// Test Client model
    /// </summary>
    [TestFixture]
    public class ClientUnitTest
    {
        private Client _client;

        /// <summary>
        /// Initialize Client unit tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _client = new Client(ObjectId.GenerateNewId(), "HashedTestPassword", new RegisterClientDataStructure()
            {
                Login = "TestLogin",
                Name = "TestName",
                Password = "TestPassword",
                Surname = "TestSurname"
            });
        }

        /// <summary>
        /// client has User role
        /// </summary>
        [Test]
        public void Client_HasUserRole()
        {
            var result = _client.Roles.Contains("User");
            Assert.True(result, "Client has \"User\" role");
        }

        /// <summary>
        /// Client has client role
        /// </summary>
        [Test]
        public void Client_HasClientRole()
        {
            var result = _client.Roles.Contains("Client");
            Assert.True(result, "Client has \"Client\" role");
        }

        /// <summary>
        /// Extend should create subscription aggregate in Client
        /// </summary>
        [Test]
        public void Client_ShouldCreateSubscriptionCreateAggregate()
        {
            var gymPass = CreateTestGymPass();
            _client.ExtendPass(gymPass);
            Assert.IsNotNull(_client.Subscription, "Subscription has not to be null");
        }

        /// <summary>
        /// The subscription extension is the customer's first subscription, the starting day should be today
        /// </summary>
        [Test]
        public void Client_IfFirstSubscriptionStartDateShouldBeToday()
        {
            var gymPass = CreateTestGymPass();
            _client.ExtendPass(gymPass);

            var compareResult = _client.Subscription.StartDate.DayOfYear - DateTime.Now.DayOfYear;
            Assert.Zero(compareResult, "Start date of first subscription should be today");
        }

        /// <summary>
        /// Ten day pass extend subscription by ten days.
        /// </summary>
        [Test]
        public void Client_HasValidEndDate()
        {
            var gymPass = CreateTestGymPass();
            var endDate = DateTime.Now;
            endDate = endDate.AddDays(10);

            _client.ExtendPass(gymPass);

            var compareResult = _client.Subscription.EndDate.DayOfYear - endDate.DayOfYear;
            Assert.Zero(compareResult, "Ten day pass extend subscription by ten day");
        }

        /// <summary>
        /// Another extension of the subscription card should extend the subscription for another days.
        /// </summary>
        [Test]
        public void Client_SecondGymPassExtendEndDate()
        {
            var gymPass = CreateTestGymPass();
            var endDate = DateTime.Now;
            endDate = endDate.AddDays(20);

            _client.ExtendPass(gymPass);
            _client.ExtendPass(gymPass);

            var compareResult = _client.Subscription.EndDate.DayOfYear - endDate.DayOfYear;
            Assert.Zero(compareResult, "Another extensions should add days to subscription duration");
        }

        /// <summary>
        /// Client extend gym pass. Client HasActiveSubscription has to be true.
        /// </summary>
        [Test]
        public void Client_ReturnTrueIfSubscriptionIsValid()
        {
            var gymPass = CreateTestGymPass();
            _client.ExtendPass(gymPass);

            Assert.True(_client.HasActiveSubscription, "Client has valid subscription if extend gym pass");
        }

        /// <summary>
        /// New Client doesn't has subscription.
        /// </summary>
        [Test]
        public void Client_NewUserNotHasSubscription()
        {
            Assert.False(_client.HasActiveSubscription, "Client doesn't has valid subscription if new.");
        }

        private GymPassType CreateTestGymPass() =>
            new GymPassType(ObjectId.GenerateNewId(), new CreateGymPassTypeDataStructure
            {
                Duration = 10,
                Id = ObjectId.GenerateNewId(),
                Name = "TestGymPass",
                Price = 100
            });
    }
}