using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Location.DTO;

namespace Tracker.Location.API.Middlewares
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
            this.CreateMap<Tracker.Location.Data.Models.Location, LocationDto>().ReverseMap();
        }
    }
}
