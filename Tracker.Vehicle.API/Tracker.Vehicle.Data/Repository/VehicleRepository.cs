using Tracker.Vehicle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Vehicle.Data;
using Microsoft.Extensions.Configuration;

namespace Tracker.Vehicle.Data.Repository
{
    /// <summary>
    /// The repository class for vehicle.
    /// </summary>
    public class VehicleRepository : RepositoryBase<Tracker.Vehicle.Data.Models.Vehicle>, IVehicleRepository
    {
        /// <summary>
        /// Constructor of vehicle repository class.
        /// </summary>
        /// <param name="repositoryContext">The database context instance.</param>
        public VehicleRepository(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
