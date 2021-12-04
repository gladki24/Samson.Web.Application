using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// PersonalTrainer domain to represent gym personal trainer.
    /// </summary>
    public class PersonalTrainer : User
    {
        public ObjectId? PupilsGroupId { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="password">Hashed password</param>
        /// <param name="dataStructure">Data structure to create Personal trainer</param>
        public PersonalTrainer(ObjectId id, string password, CreatePersonalTrainerDataStructure dataStructure)
            : base(id, password, dataStructure)
        {
            Roles.Add("PersonalTrainer");
            PupilsGroupId = dataStructure.PupilGroupId;
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public PersonalTrainer()
        {
        }
    }
}
