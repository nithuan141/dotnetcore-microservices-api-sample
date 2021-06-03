using Tracker.User.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.User.Data;

namespace Tracker.User.Data.Repository
{
    /// <summary>
    /// The repository class for Locatio.
    /// </summary>
    public class UserRepository : RepositoryBase<Tracker.User.Data.Models.User>, IUserRepository
    {
        /// <summary>
        /// Constructor of location repository class.
        /// </summary>
        /// <param name="repositoryContext">The database context instance.</param>
        public UserRepository(TrackerUserDBContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
