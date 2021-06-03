using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tracker.Vehicle.API.Validators;
using Tracker.Vehicle.DTO;

namespace Tracker.Vehicle.API.Middlewares
{
    /// <summary>
    /// Fluent validation configuration extension class.
    /// </summary>
    public static class FluentValidationConfiguration
    {
        /// <summary>
        /// Configuring the fluent validation.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            // services.AddTransient<IValidator<LocationDto>, LocationValidator>();
        }
    }
}
