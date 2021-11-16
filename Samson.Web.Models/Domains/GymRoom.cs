using MongoDB.Bson;
using Samson.Web.Application.Infrastructure;
using System;

namespace Samson.Web.Application.Models.Domains
{
    /// <summary>
    /// Represent gym room.
    /// </summary>
    public class GymRoom : IAggregate
    {
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public Tuple<int, int> Dimensions { get; private set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Key</param>
        /// <param name="name">Name of room</param>
        /// <param name="dimensions">Dimensions of room</param>
        public GymRoom(ObjectId id, string name, Tuple<int, int> dimensions)
        {
            Id = id;
            Name = name;
            Dimensions = dimensions;
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public GymRoom()
        {
        }

        /// <summary>
        /// Return area of room
        /// </summary>
        /// <returns>Area of room</returns>
        public int GetArea()
            => Dimensions.Item1 * Dimensions.Item2;
    }
}
