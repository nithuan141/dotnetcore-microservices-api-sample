using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tracker.Vehicle.Data;
using Tracker.Vehicle.Data.Repository;
using Tracker.Vehicle.Service;

namespace Tracker.Vehicle.API.Middlewares
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
           services.AddScoped<IVehicleService, VehicleService>();
        }

        /// <summary>
        /// Configuring the DI mapping for repository.
        /// </summary>
        /// <param name="services">Service collection object.</param>
        private static void ConfigureRepository(IServiceCollection services)
        {
           services.AddScoped<IVehicleRepository, VehicleRepository>();
           services.AddScoped<ILocationRepository, LocationRepository>();
        }

        /// <summary>
        /// Adding the initial data.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="context"></param>
        public static void SetUpInitialData(this IApplicationBuilder app)
        {
            //using var scope = app.ApplicationServices.CreateScope();
            //var context = scope.ServiceProvider.GetRequiredService<AssetServiceContext>();

            //var adminUser = new User()
            //{
            //    UserName = "Admin",
            //    Password = PasswordHelper.Encrypt("Admin123"),
            //    Role = "Admin",
            //    CreatedDate = DateTime.UtcNow,
            //    CreateBy = "System",
            //    Status = 0
            //};

            //context.User.Add(adminUser);
            //context.SaveChangesAsync();
        }
    }
}
