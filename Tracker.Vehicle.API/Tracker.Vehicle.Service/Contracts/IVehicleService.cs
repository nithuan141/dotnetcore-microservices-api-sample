using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Vehicle.DTO;

namespace Tracker.Vehicle.Service
{
    public interface IVehicleService
    {
        /// <summary>
        /// Create a new vehicle.
        /// </summary>
        /// <param name="locationDto">the vehicle data object</param>
        /// <returns></returns>
        Task<VehicleDTO> Createvehicle(VehicleDTO vehicleDTO, string token);

        /// <summary>
        /// Returns the current location of the vehicle.
        /// </summary>
        /// <param name="vehicleid"></param>
        /// <returns></returns>
        Task<VehicleLocationDTO> GetCurrentLocation(Guid vehicleid);

        /// <summary>
        /// Fetches and returns the location of the given vehicle at a specific time
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="dateTime"></param>
        /// <returns>Location object</returns>
        Task<LocationDTO> GetLocationOnTime(Guid vehicleId, DateTime dateTime);
    }
}
