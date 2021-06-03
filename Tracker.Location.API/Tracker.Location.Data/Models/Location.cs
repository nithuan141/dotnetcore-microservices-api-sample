using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tracker.Location.Data.Models
{
    public class Location
    {
        public Guid VehicleId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public DateTime LoggedDateTime { get; set; }
    }
}
