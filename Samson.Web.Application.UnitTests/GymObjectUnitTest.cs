using System;
using System.Collections.Generic;
using MongoDB.Bson;
using NUnit.Framework;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.UnitTests
{
    /// <summary>
    /// Test GymObject unit tests.
    /// </summary>
    [TestFixture]
    public class GymObjectUnitTest
    {
        private GymObject _gymObject;

        /// <summary>
        /// Initialize GymObject tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            decimal factory = 0.2m;

            _gymObject = new GymObject(
                ObjectId.GenerateNewId(),
                "GymObjectTest",
                new CovidConfiguration(ObjectId.Empty, factory, true),
                new List<GymRoom>()
            );
        }

        /// <summary>
        /// GymObject give possibility to calculate area of space for exercise
        /// </summary>
        [Test]
        public void GymObject_CalculateArea()
        {
            _gymObject.Rooms.Add(
                new GymRoom(ObjectId.GenerateNewId(), "TestRoom", new Tuple<int, int>(5, 10)));
            _gymObject.Rooms.Add(
                new GymRoom(ObjectId.GenerateNewId(), "TestRoom", new Tuple<int, int>(2, 10)));

            Assert.AreEqual(_gymObject.GymObjectArea(), 70, 0, "Gym object calculate area of exercise space");
        }

        /// <summary>
        /// GymObject give possibility to calculate maximum number of people based on rooms area and covid configuration
        /// </summary>
        [Test]
        public void GymObject_CalculateMaximumNumberOfPeople()
        {
            _gymObject.Rooms.Add(
                new GymRoom(ObjectId.GenerateNewId(), "TestRoom", new Tuple<int, int>(5, 10)));
            _gymObject.Rooms.Add(
                new GymRoom(ObjectId.GenerateNewId(), "TestRoom", new Tuple<int, int>(2, 10)));

            Assert.AreEqual(_gymObject.CalcMaximumClientsCount(), 14, 1, "Gym object calculate maximum number of people in object");
        }
    }
}