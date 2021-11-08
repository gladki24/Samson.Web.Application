using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create User domain.
    /// </summary>
    [Factory]
    public class UserFactory : IUserFactory
    {
    public User Create(CreateUserDataStructure dataStructure) =>
        new User(ObjectId.GenerateNewId(), dataStructure);
    }
}
