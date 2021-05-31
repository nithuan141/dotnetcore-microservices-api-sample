using System;
using Microsoft.EntityFrameworkCore;

namespace Tracker.API.Models
{
    public partial class TrackerDBContext : DbContext
    {
        public TrackerDBContext()
        {
        }

        public TrackerDBContext(DbContextOptions<TrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
    }
}
