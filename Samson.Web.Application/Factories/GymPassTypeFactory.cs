using MongoDB.Bson;
using Samson.Web.Application.Factories.Interfaces;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.DataStructures.GymPass;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories
{
    /// <summary>
    /// Factory to create gym pass model
    /// </summary>
    [Factory]
    public class GymPassTypeFactory : IGymPassTypeFactory
    {
        /// <summary>
        /// Create GymPass model with id generation
        /// </summary>
        /// <param name="dataStructure">Information about GymPass</param>
        /// <returns>GymPass</returns>
        public GymPassType CreateGymPassType(CreateGymPassTypeDataStructure dataStructure)
            => new GymPassType(ObjectId.GenerateNewId(), dataStructure);
    }
}
