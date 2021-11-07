using MediatR;
using MongoDB.Bson;

namespace Samson.Web.Application.Commands.GymPass
{
    /// <summary>
    /// Command to create GymPassType
    /// </summary>
    public class CreateGymPassTypeCommand : IRequest<ObjectId>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
