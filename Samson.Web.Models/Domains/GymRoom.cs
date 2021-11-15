using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using System;

namespace Samson.Web.Application.Models.Domains
{
    public class GymRoom : IAggregate
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }


        public GymRoom(ObjectId id, string name, Tuple<int, int> dimensions)
        {
            Id = id;
            Name = name;
            Dimensions = dimensions;
        }
    }
}
