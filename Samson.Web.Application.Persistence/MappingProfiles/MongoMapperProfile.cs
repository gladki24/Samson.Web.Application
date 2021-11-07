using AutoMapper;
using MongoDB.Bson;

namespace Samson.Web.Application.Persistence.MappingProfiles
{
    /// <summary>
    /// Mapping profile to map object related to MongoDB infrastructure
    /// </summary>
    public class MongoMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MongoMapperProfile()
        {
            CreateMap<string, ObjectId>().ConstructUsing(objectIdString => new ObjectId(objectIdString));
            CreateMap<ObjectId, string>().ConstructUsing(objectId => objectId.ToString());
        }
    }
}
