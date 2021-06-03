using Tracker.Location.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Location.Data.Repository
{
    public interface ILocationRepository: IRepositoryBase<Tracker.Location.Data.Models.Location>
    {
    }
}
