using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.User;

namespace Samson.Web.Application.Queries.User
{
    /// <summary>
    /// Query to get User by id.
    /// </summary>
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        public GetUserByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
