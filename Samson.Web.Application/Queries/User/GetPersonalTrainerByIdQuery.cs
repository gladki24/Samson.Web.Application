using MediatR;
using MongoDB.Bson;
using Samson.Web.Application.Models.Dtos.User;

namespace Samson.Web.Application.Queries.User
{
    /// <summary>
    /// Query to get PersonalTrainer by id.
    /// </summary>
    public class GetPersonalTrainerByIdQuery : IRequest<PersonalTrainerDto>
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="id">Key</param>
        public GetPersonalTrainerByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
