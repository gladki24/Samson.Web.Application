using System.Collections.Generic;
using System.Threading.Tasks;
using Samson.Web.Application.Infrastructure.Attributes;
using Samson.Web.Application.Models.Dtos;
using Samson.Web.Application.ReadModels.Interfaces;

namespace Samson.Web.Application.ReadModels
{
    /// <summary>
    /// Implementation of read model to get information about available gym passes
    /// </summary>
    [ReadModel]
    public class GymPassReadModel : IGymPassReadModel
    {
        /// <summary>
        /// Get all available gym pass types
        /// </summary>
        /// <returns>List of available passes in gym offer</returns>
        public Task<List<GymPassTypeDto>> GetPassTypes()
        {
            var passTypes = new List<GymPassTypeDto>
            {
                new GymPassTypeDto(),
                new GymPassTypeDto(),
                new GymPassTypeDto()
            };

            return Task.FromResult(passTypes);
        }
    }
}
