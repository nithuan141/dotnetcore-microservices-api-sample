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
    /// The repository class for Locatio.
    /// </summary>
    public class LocationRepository : RepositoryBase<Tracker.Vehicle.Data.Models.Location>, ILocationRepository
    {
        /// <summary>
        /// Constructor of location repository class.
        /// </summary>
        /// <param name="repositoryContext">The database context instance.</param>
        public LocationRepository(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
