using System;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.GymObject
{
    public class GymRoomDto
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public Tuple<int, int> Dimensions { get; set; }
    }
}
