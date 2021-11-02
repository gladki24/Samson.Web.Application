using MongoDB.Bson;

namespace Samson.Web.Application.Infrastructure
{
    /// <summary>
    /// Model able to store in data source
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Key of entity
        /// </summary>
        ObjectId Id { get; set; }
    }
}
