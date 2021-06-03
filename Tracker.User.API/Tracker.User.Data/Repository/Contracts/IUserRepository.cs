using Tracker.User.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.User.Data.Repository
{
    public interface IUserRepository: IRepositoryBase<Tracker.User.Data.Models.User>
    {
    }
}
