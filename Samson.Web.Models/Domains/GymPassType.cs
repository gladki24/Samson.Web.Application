using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.DataStructures.GymPass;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represents gym pass type subscription.
    /// </summary>
    public class GymPassType : IAggregate
    {
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="dataStructure">Data structure to create GymPassType</param>
        public GymPassType(ObjectId id, CreateGymPassTypeDataStructure dataStructure)
        {
            Id = id;
            Name = dataStructure.Name;
            Price = dataStructure.Price;
            Duration = dataStructure.Duration;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public GymPassType()
        {
        }

        /// <summary>
        /// Update model by data structure
        /// </summary>
        /// <param name="dataStructure">Data structure of GymPassType domain</param>
        public void Update(UpdateGymPassTypeDataStructure dataStructure)
        {
            Name = dataStructure.Name;
            Price = dataStructure.Price;
            Duration = dataStructure.Duration;
        }
    }
}
