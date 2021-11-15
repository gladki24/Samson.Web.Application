using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create User and related classes.
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// Create PersonalTrainer from data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create PersonalTrainer aggregate</param>
        /// <returns>PersonalTrainer aggregate</returns>
        PersonalTrainer CreatePersonalTrainer(CreatePersonalTrainerDataStructure dataStructure);

        /// <summary>
        /// Create Client from data structure.
        /// </summary>
        /// <param name="dataStructure">Data structure to create Client aggregate</param>
        /// <returns>Client aggregate</returns>
        Client CreateClient(RegisterClientDataStructure dataStructure);
    }
}
