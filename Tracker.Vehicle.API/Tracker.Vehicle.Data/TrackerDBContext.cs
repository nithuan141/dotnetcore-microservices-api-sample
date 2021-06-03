using System;
using Microsoft.EntityFrameworkCore;
using Tracker.Vehicle.Data.Models;

namespace Tracker.Vehicle.Data
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Location>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Models.Vehicle>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Models.Vehicle> Vehicle { get; set; }
    }
}
