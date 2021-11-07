using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.GymPass
{
    /// <summary>
    /// Command to update GymPassType
    /// </summary>
    public class UpdateGymPassTypeCommand : IRequest<ObjectId>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
