using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tracker.User.Data;
using Tracker.User.Data.Repository;
using Tracker.User.Service;

namespace Tracker.User.API.Middlewares
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
            var connectionString = configuration.GetSection("ConnectionString:TrackerUserDB").Value;
            services.AddDbContext<TrackerUserDBContext>(options => options.UseInMemoryDatabase(databaseName: "TrackerUserDB"));
        }

        /// <summary>
        /// Configuring the DI mapping for services.
        /// </summary>
        /// <param name="services">Service collection object.</param>
        private static void ConfigureServices(IServiceCollection services)
        {
           services.AddScoped<IUserService, UserService>();
           services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
        }

        /// <summary>
        /// Configuring the DI mapping for repository.
        /// </summary>
        /// <param name="services">Service collection object.</param>
        private static void ConfigureRepository(IServiceCollection services)
        {
           services.AddScoped<IUserRepository, UserRepository>();
        }

        /// <summary>
        /// Adding the initial data.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="context"></param>
        public static void SetUpInitialData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TrackerUserDBContext>();

            var adminUser = new Data.Models.User()
            {
                UserName = "Admin",
                Password = PasswordHelper.Encrypt("Admin@123"),
                Role = "Admin",
                CreatedDate = DateTime.UtcNow,
                CreateBy = "System",
                Status = 0
            };

            var vehicleUser1 = new Data.Models.User()
            {
                UserName = "AXC340",
                Password = PasswordHelper.Encrypt("Vehicle@123"),
                Role = "Vehicle",
                CreatedDate = DateTime.UtcNow,
                CreateBy = "System",
                Status = 0
            };

            var vehicleUser2 = new Data.Models.User()
            {
                UserName = "AXC350",
                Password = PasswordHelper.Encrypt("Vehicle@123"),
                Role = "Vehicle",
                CreatedDate = DateTime.UtcNow,
                CreateBy = "System",
                Status = 0
            };

            context.User.Add(adminUser);
            context.User.Add(vehicleUser1);
            context.User.Add(vehicleUser2);

            context.SaveChangesAsync();
        }
    }
}
