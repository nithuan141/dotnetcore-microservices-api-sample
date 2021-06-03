using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.User.DTO;
using Tracker.User.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.User.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // The User service instance
        private readonly IUserService userService;

        public UserController(IUserService locService)
        {
            this.userService = locService;
        }

        // POST api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO UserDto)
        {
            var result  = await this.userService.Create(UserDto);

            return Ok(result);
        }
    }
}
