using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.User.DTO;

namespace Tracker.User.API.Middlewares
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
            this.CreateMap<Tracker.User.Data.Models.User, UserDTO>().ReverseMap();
        }
    }
}
