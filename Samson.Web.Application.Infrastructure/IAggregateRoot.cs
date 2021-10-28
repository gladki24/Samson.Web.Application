using MongoDB.Bson;

namespace Samson.Web.Application.Infrastructure
{
    public interface IAggregateRoot
    {
        ObjectId Id { get; set; }
    }
}
