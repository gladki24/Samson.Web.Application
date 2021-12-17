using MongoDB.Bson;
using NUnit.Framework;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.UnitTests
{
    /// <summary>
    /// Test PersonalTrainer model
    /// </summary>
    [TestFixture]
    public class PersonalTrainerUnitTest
    {
        private PersonalTrainer _personalTrainer;

        /// <summary>
        /// Initialize PersonalTrainer unit tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _personalTrainer = new PersonalTrainer(ObjectId.GenerateNewId(),
                "HashedTestPassword", new CreatePersonalTrainerDataStructure()
                {
                    Name = "TestName",
                    Login = "TestLogin",
                    Password = "TestPassword",
                    PupilGroupId = null,
                    Surname = "TestSurname"
                });
        }

        /// <summary>
        /// Personal trainer has User role
        /// </summary>
        [Test]
        public void PersonalTrainer_HasUserRole()
        {
            var result = _personalTrainer.Roles.Contains("User");
            Assert.True(result, "PersonalTrainer has \"User\" role");
        }

        /// <summary>
        /// Personal trainer has PersonalTrainer role
        /// </summary>
        [Test]
        public void PersonalTrainer_HasPersonalTrainerRole()
        {
            var result = _personalTrainer.Roles.Contains("PersonalTrainer");
            Assert.True(result, "PersonalTrainer has \"PersonalTrainer\" role.");
        }
    }
}
