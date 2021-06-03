using ApiBase.Common;
using AutoMapper;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tracker.Vehicle.Data.Repository;
using Tracker.Vehicle.DTO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Tracker.Vehicle.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IMapper mapper;
        private readonly ILocationRepository locationRepository;
        private readonly IConfiguration configuration;

        // TODO: Move this to keyvault
        const string MAP_BOX_TOKEN = "pk.eyJ1Ijoibml0aHVhbjE0MSIsImEiOiJjazNsbjFmaHowOGhmM2lzMzhzbXgxaWdiIn0.clzt1jNW-HnG09bsDu2Yyw";
        const string MAP_BOX_API = "https://api.mapbox.com/geocoding/v5/mapbox.places/";

        public VehicleService(IVehicleRepository vehicleRepo, ILocationRepository locRepo, IMapper map, IConfiguration config)
        {
            this.vehicleRepository = vehicleRepo;
            this.mapper = map;
            this.locationRepository = locRepo;
            this.configuration = config;
        }

        /// <summary>
        /// Create a new vehicle.
        /// </summary>
        /// <param name="locationDto">the vehicle data object</param>
        /// <returns></returns>
        public async Task<VehicleDTO> Createvehicle(VehicleDTO vehicleDTO, string token)
        {
            var vehicle = this.mapper.Map<Data.Models.Vehicle>(vehicleDTO);
            await this.vehicleRepository.Create(vehicle);
            vehicleDTO.VehicleId = vehicle.VehicleId;
            var userCreated = await this.vehicleRepository.CreateUserForVehicle(vehicle, token);
            return vehicleDTO;
        }

        /// <summary>
        /// Finds the latest location of the given vehicle.
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public async Task<VehicleLocationDTO> GetCurrentLocation(Guid vehicleId)
        {
            MapLocation locationMap = new MapLocation();

            var locations = await this.locationRepository.FindByCondition(x => x.VehicleId == vehicleId, "Location");
            var location = locations.OrderByDescending(x => x.LoggedDateTime).FirstOrDefault();

            if (location == null)
            {
                throw new InvalidDataException("There is no location record for the given vehicle.");
            }

            // TODO: Move this to a data layer and make it generic
            using (var httpClinet = new HttpClient())
            {
                HttpResponseMessage response = await httpClinet.GetAsync($"{MAP_BOX_API}{location.Longitude},{location.Latitude}.json?access_token={MAP_BOX_TOKEN}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    locationMap = JsonConvert.DeserializeObject<MapLocation>(content);
                }

            }

            return new VehicleLocationDTO()
            {
                Longitude = location.Longitude,
                Lattitude = location.Latitude,
                LocationName = locationMap.Features.FirstOrDefault().Place_Name,
                VehicleId = vehicleId
            };

        }

        /// <summary>
        /// Fetches and returns the location of the given vehicle at a specific time
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="dateTime"></param>
        /// <returns>Location object</returns>
        public async Task<LocationDTO> GetLocationOnTime(Guid vehicleId, DateTime dateTime)
        {
            MapLocation locationMap = new MapLocation();

            // Fetching the location for given time, adding a 30 seconds window , considering the differnce in logge and fetched date time.
            var locations = await this.locationRepository.FindByCondition(x => x.VehicleId == vehicleId && x.LoggedDateTime < dateTime.AddSeconds(15) && x.LoggedDateTime > dateTime.AddSeconds(-15), "Location");
            var location = locations.OrderByDescending(x => x.LoggedDateTime).FirstOrDefault();

            if (location == null)
            {
                throw new InvalidDataException("There is no location record for the given vehicle.");
            }

            return this.mapper.Map<LocationDTO>(location);
        }
    }
}
