using Tracker.Vehicle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Vehicle.Data;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace Tracker.Vehicle.Data.Repository
{
    /// <summary>
    /// The repository class for vehicle.
    /// </summary>
    public class VehicleRepository : RepositoryBase<Tracker.Vehicle.Data.Models.Vehicle>, IVehicleRepository
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Constructor of vehicle repository class.
        /// </summary>
        /// <param name="repositoryContext">The database context instance.</param>
        public VehicleRepository(IConfiguration config)
            : base(config)
        {
            this.configuration = config;
        }

        /// <summary>
        /// Call the user create API and create user for the new vehicle
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CreateUserForVehicle(Data.Models.Vehicle vehicle, string token)
        {
            string userCreateApi = this.configuration.GetSection("UserAPI:create").Value;
            using (var httpClinet = new HttpClient())
            {
                httpClinet.DefaultRequestHeaders.Clear();
                httpClinet.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", token);
                var userData = new { UserName = vehicle.VehicleNo, Password = "Default@123", Role = "Vehicle", Status = 1, CreateBy = "Vehicle Service", CreateDate = DateTime.UtcNow };
                var response = await httpClinet.PostAsync(userCreateApi, new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
