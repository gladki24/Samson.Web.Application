using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    public interface IUserFactory
    {
        PersonalTrainer CreatePersonalTrainer(CreatePersonalTrainerDataStructure dataStructure);
        Client CreateClient(RegisterClientDataStructure dataStructure);
    }
}
