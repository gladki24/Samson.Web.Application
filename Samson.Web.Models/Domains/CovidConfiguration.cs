using MongoDB.Bson;
using Samson.Web.Application.Models.DataStructures;
using Samson.Web.Application.Models.DataStructures.GymObject;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent actual configuration of COVID restriction
    /// </summary>
    public class CovidConfiguration
    {
        public ObjectId Id { get; set; }
        public decimal PersonFactorPerMeter { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key of configuration</param>
        /// <param name="personFactorPerMeter">How many person can be on one meter of floor</param>
        /// <param name="isActive">Is COVID configuration enabled</param>
        public CovidConfiguration(ObjectId id, decimal personFactorPerMeter, bool isActive)
        {
            Id = id;
            PersonFactorPerMeter = personFactorPerMeter;
            IsActive = isActive;
        }


        /// <summary>
        /// Update model from data structure
        /// </summary>
        /// <param name="dataStructure">Data structure of CovidConfiguration domain</param>
        public void Update(CovidConfigurationDataStructure dataStructure)
        {
            PersonFactorPerMeter = dataStructure.PersonFactorPerMeter;
            IsActive = dataStructure.IsActive;
        }
    }
}
