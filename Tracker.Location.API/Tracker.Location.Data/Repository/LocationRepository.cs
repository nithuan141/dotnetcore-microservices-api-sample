using Tracker.Location.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Location.Data;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Tracker.Location.Data.Repository
{
    /// <summary>
    /// The repository class for Locatio.
    /// </summary>
    public class LocationRepository : RepositoryBase<Tracker.Location.Data.Models.Location>, ILocationRepository
    {
           /// <summary>
        /// Constructor of location repository class.
        /// </summary>
        /// <param name="configuration">The configuration instance.</param>
        public LocationRepository(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
