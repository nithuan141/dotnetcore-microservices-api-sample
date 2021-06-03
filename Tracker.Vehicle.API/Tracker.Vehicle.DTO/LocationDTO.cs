using System;
using System.Text.Json.Serialization;

namespace Tracker.Vehicle.DTO
{
    public class LocationDTO
    {
        [JsonPropertyName("VehicleId")]
        public Guid VehicleId { get; set; }

        [JsonPropertyName("Longitude")]
        public float Longitude { get; set; }

        [JsonPropertyName("Latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("LoggedAt")]
        public DateTime LoggedDateTime { get; set; }
    }
}
