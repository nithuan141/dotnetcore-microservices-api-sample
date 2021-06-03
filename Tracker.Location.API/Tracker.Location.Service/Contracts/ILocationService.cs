using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Location.DTO;

namespace Tracker.Location.Service
{
    public interface ILocationService
    {
        /// <summary>
        /// Create a new location entry for a vehicle.
        /// </summary>
        /// <param name="locationDto">the location data object</param>
        /// <returns></returns>
        Task SaveVehicleLocation(LocationDto locationDto);
    }
}
