using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker.Vehicle.Data.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public string VehicleNo { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
