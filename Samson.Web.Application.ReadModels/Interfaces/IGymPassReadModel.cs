using System.Collections.Generic;
using System.Threading.Tasks;
using Samson.Web.Application.Models.Dtos;

namespace Samson.Web.Application.ReadModels.Interfaces
{
    /// <summary>
    /// Read model to get information about available gym passes
    /// </summary>
    public interface IGymPassReadModel
    {
        /// <summary>
        /// Get all available gym pass types
        /// </summary>
        /// <returns>List of available passes in gym offer</returns>
        Task<List<GymPassTypeDto>> GetPassTypes();
    }
}
