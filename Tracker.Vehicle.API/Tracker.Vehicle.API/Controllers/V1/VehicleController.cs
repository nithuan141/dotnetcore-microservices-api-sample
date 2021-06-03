using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Vehicle.DTO;
using Tracker.Vehicle.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.Vehicle.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // The Vehicle service instance
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehiService)
        {
            this.vehicleService = vehiService;
        }

        // POST api/Vehicle
        [HttpPost]
        //[Authorize(Roles="Admin")]
        public async Task<IActionResult> Post([FromBody] VehicleDTO VehicleDto)
        {
            var token = await this.HttpContext.GetTokenAsync("access_token");
            var result = await this.vehicleService.Createvehicle(VehicleDto, token);

            return Ok(result);
        }

        [HttpGet("{vehicleId}/location/current")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CurrentLocation(Guid vehicleId)
        {
            var result = await this.vehicleService.GetCurrentLocation(vehicleId);

            return Ok(result);
        }
        [HttpGet("{vehicleId}/location/{dateTime}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Location(Guid vehicleId, DateTime dateTime)
        {
            var result = await this.vehicleService.GetLocationOnTime(vehicleId, dateTime);

            return Ok(result);
        }
    }
}
