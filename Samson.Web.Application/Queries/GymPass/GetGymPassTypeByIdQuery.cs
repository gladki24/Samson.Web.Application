using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymPass;

namespace Samson.Web.Application.Queries.GymPass
{
    /// <summary>
    /// Query to get GymPassType by id.
    /// </summary>
    public class GetGymPassTypeByIdQuery : IRequest<GymPassTypeDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        public GetGymPassTypeByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}