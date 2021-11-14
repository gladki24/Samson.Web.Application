using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.User;

namespace Samson.Web.Application.Queries.User
{
    /// <summary>
    /// Query to get Client by id
    /// </summary>
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        public GetClientByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
