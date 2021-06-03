using System;
using System.Threading.Tasks;
using ApiBase.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracker.Location.DTO;
using Tracker.Location.Service;

namespace Tracker.Location.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // The location service instance
        private readonly ILocationService locationService;

        public LocationController(ILocationService locService)
        {
            this.locationService = locService;
        }

        // POST api/location
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] LocationDto locationDto)
        {
            await this.HttpContext.ValidateSelfAccess(locationDto.VehicleNo);
            await this.locationService.SaveVehicleLocation(locationDto);

            return Ok();
        }
    }
}
