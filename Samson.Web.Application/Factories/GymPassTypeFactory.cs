using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    [Factory]
    public class GymPassTypeFactory : IGymPassTypeFactory
    {
        public GymPassType CreateGymPassType(CreateGymPassTypeDataStructure dataStructure)
            => new GymPassType(ObjectId.GenerateNewId(), dataStructure);
    }
}
