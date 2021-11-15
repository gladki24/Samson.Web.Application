using MongoDB.Bson;

namespace Samson.Web.Application.Infrastructure
{
    /// <summary>
    /// Represent root of aggregate
    /// </summary>
    public interface IAggregate
    {
        /// <summary>
        /// Key of aggregate
        /// </summary>
        ObjectId Id { get; }
    }
}
