using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.GymObject;

namespace Samson.Web.Application.Queries.GymObject
{
    /// <summary>
    /// Query to get GymObject by id
    /// </summary>
    public class GymObjectQuery : IRequest<GymObjectDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key</param>
        public GymObjectQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
