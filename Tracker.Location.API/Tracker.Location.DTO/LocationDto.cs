using System;
using System.Text.Json.Serialization;

namespace Tracker.Location.DTO
{
    public class LocationDto
    {
        [JsonPropertyName("VehicleId")]
        public Guid VehicleId { get; set; }

        [JsonPropertyName("VehicleNo")]
        public string VehicleNo { get; set; }

        [JsonPropertyName("Longitude")]
        public float Longitude { get; set; }

        [JsonPropertyName("Latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("LoggedAt")]
        public DateTime LoggedDateTime { get; set; }
    }
}
