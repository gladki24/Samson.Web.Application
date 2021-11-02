using MongoDB.Bson;

namespace Samson.Web.Application.Infrastructure
{
    /// <summary>
    /// Represent root of aggregate
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        /// Key of aggregate
        /// </summary>
        ObjectId Id { get; }
    }
}
