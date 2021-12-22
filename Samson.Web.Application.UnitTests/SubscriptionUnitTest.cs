using System;
using MongoDB.Bson;
using NUnit.Framework;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.UnitTests
{
    /// <summary>
    /// Test Subscription model
    /// </summary>
    [TestFixture]
    public class SubscriptionUnitTest
    {
        private Subscription _subscription;

        /// <summary>
        /// Initialize Subscription unit tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var today = DateTime.Now;
            var weekLater = today.AddDays(7);
            _subscription = new Subscription(ObjectId.GenerateNewId(), DateTime.Now, weekLater, ObjectId.Empty);
        }

        /// <summary>
        /// The subscription is valid if today's date is in the range.
        /// </summary>
        [Test]
        public void Subscription_IsValid()
        {
            var result = _subscription.IsActive;
            Assert.True(result, "The subscription is valid if today's date is in the range.");
        }

        /// <summary>
        /// The subscription is invalid if today's date isn't in the range.
        /// </summary>
        [Test]
        public void Subscription_IsInvalid()
        {
            var today = DateTime.Now;
            var weekAgo = today.AddDays(-7);
            var dayAgo = today.AddDays(-1);

            _subscription = new Subscription(
                ObjectId.GenerateNewId(),
                weekAgo,
                dayAgo,
                ObjectId.Empty
            );

            var result = _subscription.IsActive;
            Assert.False(result, "The subscription is invalid if today's date isn't in the range.");
        }
    }
}