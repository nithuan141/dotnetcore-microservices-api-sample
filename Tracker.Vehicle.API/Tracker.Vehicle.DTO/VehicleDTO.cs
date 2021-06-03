using System;
using System.Text.Json.Serialization;

namespace Tracker.Vehicle.DTO
{
    public class VehicleDTO
    {
        [JsonPropertyName("VehicleId")]
        public Guid VehicleId { get; set; }

        [JsonPropertyName("VehicleNo")]
        public string VehicleNo { get; set; }

        [JsonPropertyName("RegistrationNo")]
        public string RegistrationNo { get; set; }

        [JsonPropertyName("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonPropertyName("UpdatedBy")]
        public string UpdatedBy { get; set; }
    }
}
