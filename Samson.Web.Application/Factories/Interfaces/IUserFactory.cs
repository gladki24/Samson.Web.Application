using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    public interface IUserFactory
    {
        User Create(CreateUserDataStructure dataStructure);
    }
}
