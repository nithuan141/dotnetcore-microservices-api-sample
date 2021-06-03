using ApiBase.Common;
using AutoMapper;
using System;
using System.Threading.Tasks;
using Tracker.Location.Data.Repository;
using Tracker.Location.Data;
using Tracker.Location.DTO;

namespace Tracker.Location.Service
{
    public class LocationService: ILocationService
    {
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;

        public LocationService(ILocationRepository locRepository, IMapper map)
        {
            this.locationRepository = locRepository;
            this.mapper = map;
        }

        /// <summary>
        /// Create a new location entry for a vehicle.
        /// </summary>
        /// <param name="locationDto">the location data object</param>
        /// <returns></returns>
        public async Task SaveVehicleLocation(LocationDto locationDto)
        {
            if(!IsValidVehicle(new Guid()))
            {
                throw new InvalidDataException("The vehicle id is invalid.");
            }

            var location = this.mapper.Map<Data.Models.Location>(locationDto);

            await this.locationRepository.Create(location);
        }

        /// <summary>
        /// validates the save request, whether it comes from correct vehicle.
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        private bool IsValidVehicle(Guid vehicleId)
        {
            // TODO: validate the device signature or the shared key of the vehicle to confirm the save call is triggered from the valid device.
            return true;
        }
    }
}
