using System;
using Microsoft.EntityFrameworkCore;
using Tracker.User.Data.Models;

namespace Tracker.User.Data
{
    public partial class TrackerUserDBContext : DbContext
    {
        public TrackerUserDBContext()
        {
        }

        public TrackerUserDBContext(DbContextOptions<TrackerUserDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.User> User { get; set; }
    }
}
