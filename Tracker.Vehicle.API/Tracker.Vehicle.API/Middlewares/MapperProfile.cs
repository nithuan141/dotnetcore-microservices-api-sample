using AutoMapper;
using System;
using Tracker.Vehicle.DTO;

namespace Tracker.Vehicle.API.Middlewares
{
    /// <summary>
    /// Automapper mapper class.
    /// </summary>
    public class MapperProfile : Profile
    {
        /// <summary>
        /// Mapper profile constructor.
        /// </summary>
        public MapperProfile()
        {
            this.CreateMap<Tracker.Vehicle.Data.Models.Vehicle, VehicleDTO>().ReverseMap();
            this.CreateMap<Tracker.Vehicle.Data.Models.Location, LocationDTO>().ReverseMap();
        }
    }
}
