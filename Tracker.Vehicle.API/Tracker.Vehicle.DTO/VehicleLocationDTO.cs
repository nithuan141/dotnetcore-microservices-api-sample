using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tracker.Vehicle.DTO
{
    public class VehicleLocationDTO
    {
        [JsonPropertyName("VehicleId")]
        public Guid VehicleId { get; set; }

        [JsonPropertyName("Location")]
        public string LocationName { get; set; }

        [JsonPropertyName("Long")]
        public float Longitude { get; set; }

        [JsonPropertyName("Lat")]
        public float Lattitude { get; set; }

    }
}
