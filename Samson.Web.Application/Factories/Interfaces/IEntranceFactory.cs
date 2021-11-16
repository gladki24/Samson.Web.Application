using Samson.Web.Application.Models.DataStructures.Gym;
using Samson.Web.Application.Models.Domains;

namespace Samson.Web.Application.Factories.Interfaces
{
    /// <summary>
    /// Factory to create instances of Entrance aggregate.
    /// </summary>
    public interface IEntranceFactory
    {
        /// <summary>
        /// Create entry aggregation.
        /// </summary>
        /// <param name="dataStructure">Information about client entrance</param>
        /// <returns>Entry aggregation</returns>
        Entrance Create(EntryDataStructure dataStructure);
    }
}