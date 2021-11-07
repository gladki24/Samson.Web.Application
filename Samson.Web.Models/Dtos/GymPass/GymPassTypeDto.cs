using System;
using MongoDB.Bson;

namespace Samson.Web.Application.Models.Dtos.GymPass
{
    public class GymPassTypeDto
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    }
}
