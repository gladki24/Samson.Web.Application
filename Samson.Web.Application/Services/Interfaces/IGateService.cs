using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models;
using Samson.Web.Application.Models.DataStructures.Gym;

namespace Samson.Web.Application.Services.Interfaces
{
    /// <summary>
    /// Service to manage gate exit and entrance to gym.
    /// </summary>
    public interface IGateService
    {
        /// <summary>
        /// Validate attempt to entry to the gym object.
        /// </summary>
        /// <param name="dataStructure">Information entrance attempt</param>
        /// <returns>Return information about entry possibility</returns>
        public Task<EntryValidationViewModel> ValidEntrance(EntryDataStructure dataStructure);

        /// <summary>
        /// Inform about client entry to gym.
        /// </summary>
        /// <param name="dataStructure">Information about client entrance</param>
        /// <returns>Entrance aggregate id</returns>
        public Task<ObjectId> Entry(EntryDataStructure dataStructure);

        /// <summary>
        /// Inform about client exit from gym.
        /// </summary>
        /// <param name="dataStructure">Information about exit</param>
        public Task<Unit> Exit(ExitDataStructure dataStructure);
    }
}