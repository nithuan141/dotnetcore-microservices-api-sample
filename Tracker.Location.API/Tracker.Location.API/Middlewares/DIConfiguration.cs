using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tracker.Location.Data;
using Tracker.Location.Data.Models;
using Tracker.Location.Data.Repository;
using Tracker.Location.Service;

namespace Tracker.Location.API.Middlewares
{
    /// <summary>
    /// Servicecollection extnetion for dependency injection mappings.
    /// </summary>
    public static class DIConfiguration
    {
        /// <summary>
        /// Configuring the DI mappings.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDI(this IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureRepository(services);
        }

        /// <summary>
        /// Extention method to configure the database connection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureDB(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO: Move the connection string to a key vault and read it from vault.
            var connectionString = configuration.GetSection("ConnectionString:KeyServiceDB").Value;
            services.AddDbContext<TrackerDBContext>(options => options.UseInMemoryDatabase(databaseName: "TrackerDB"));
        }

        /// <summary>
        /// Configuring the DI mapping for services.
        /// </summary>
        /// <param name="services">Service collection object.</param>
        private static void ConfigureServices(IServiceCollection services)
        {
           services.AddScoped<ILocationService, LocationService>();
        }

        /// <summary>
        /// Configuring the DI mapping for repository.
        /// </summary>
        /// <param name="services">Service collection object.</param>
        private static void ConfigureRepository(IServiceCollection services)
        {
           services.AddScoped<ILocationRepository, LocationRepository>();
        }

        /// <summary>
        /// Adding the initial data.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="context"></param>
        public static void SetUpInitialData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TrackerDBContext>();

            var vehicle1 = new Data.Models.Vehicle()
            {
                VehicleId = new Guid(),
                VehicleNo = "AXC340",
                RegistrationNo = "AXC340KL001",
                RegistrationDate = DateTime.UtcNow.AddYears(-2),
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "System",
                UpdatedDate = DateTime.UtcNow
            };

            var vehicle2 = new Data.Models.Vehicle()
            {
                VehicleId = new Guid(),
                VehicleNo = "AXC350",
                RegistrationNo = "AXC350KL001",
                RegistrationDate = DateTime.UtcNow.AddYears(-2),
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = "System",
                UpdatedDate = DateTime.UtcNow
            };

            //context.Vehicle.Add(vehicle1);
            //context.Vehicle.Add(vehicle2);

           // context.SaveChangesAsync();
        }
    }
}
