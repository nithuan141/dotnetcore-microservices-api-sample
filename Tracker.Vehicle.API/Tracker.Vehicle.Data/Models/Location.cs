using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker.Vehicle.Data.Models
{
    public class Location
    {
        public ObjectId _id { get; set; }
        public Guid VehicleId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public DateTime LoggedDateTime { get; set; }
    }
}
