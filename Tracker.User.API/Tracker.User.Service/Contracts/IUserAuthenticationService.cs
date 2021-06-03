using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.User.DTO;

namespace Tracker.User.Service
{
    public interface IUserAuthenticationService
    {
        /// <summary>
        /// Authenticating the given user and returning the access token.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>User data with Access Token</returns>
        Task<UserDTO> Authenticate(UserDTO user);
    }
}
