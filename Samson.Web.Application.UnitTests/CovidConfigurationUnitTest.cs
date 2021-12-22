using MongoDB.Bson;
using NUnit.Framework;
using Samson.Web.Application.Models.DataStructures.GymObject;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.UnitTests
{
    /// <summary>
    /// Test CovidConfiguration model.
    /// </summary>
    [TestFixture]
    public class CovidConfigurationUnitTest
    {
        private CovidConfiguration _configuration;

        /// <summary>
        /// Initialize CovidConfiguration tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _configuration = new CovidConfiguration(ObjectId.GenerateNewId(), 5, false);
        }

        /// <summary>
        /// CovidConfiguration should has possiblity to update model by data structure
        /// </summary>
        [Test]
        public void CovidConfiguration_UpdateByDataStructure()
        {
            _configuration.Update(new CovidConfigurationDataStructure
            {
                IsActive = true,
                PersonFactorPerMeter = 10
            });

            Assert.AreEqual(true, _configuration.IsActive, "Update to IsActive = true");
            Assert.AreEqual(10, _configuration.PersonFactorPerMeter, "Update factory to 10 person per meter");
        }
    }
}