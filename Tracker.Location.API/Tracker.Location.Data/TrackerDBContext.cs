using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tracker.Location.Data.Models;

namespace Tracker.Location.Data
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

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(x=>x.VehicleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<Models.Location> Location { get; set; }

        public virtual DbSet<Vehicle> Vehicle { get; set; }
    }
}
