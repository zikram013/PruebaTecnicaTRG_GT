using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using GtMotive.Estimate.Microservice.Infrastructure.Time;
using GtMotive.Estimate.Microservice.Infrastructure.UnitOfWork;
using GtMotive.Estimate.Microservice.Infrastructure.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    /// <summary>
    /// Provides infrastructure dependency registration.
    /// </summary>
    public static class InfrastructureConfiguration
    {
        /// <summary>
        /// Adds base infrastructure services using in-memory persistence.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="isDevelopment">A value indicating whether the application is running in development mode.</param>
        /// <returns>The infrastructure builder.</returns>
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddBaseInfrastructure(
            this IServiceCollection services,
            bool isDevelopment)
        {
            ArgumentNullException.ThrowIfNull(services);

            AddCommonInfrastructure(services, isDevelopment);

            services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();
            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();

            return new InfrastructureBuilder(services);
        }

        /// <summary>
        /// Adds base infrastructure services using SQLite persistence.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="isDevelopment">A value indicating whether the application is running in development mode.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The infrastructure builder.</returns>
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddSqliteInfrastructure(
            this IServiceCollection services,
            bool isDevelopment,
            IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(configuration);

            AddCommonInfrastructure(services, isDevelopment);

            services.AddDbContext<RentingDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("RentingDatabase"));
            });

            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IVehicleRepository, SqliteVehicleRepository>();

            return new InfrastructureBuilder(services);
        }

        private static void AddCommonInfrastructure(IServiceCollection services, bool isDevelopment)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddSingleton<IClock, SystemClock>();

            if (!isDevelopment)
            {
                services.AddScoped<ITelemetry, AppTelemetry>();
            }
            else
            {
                services.AddScoped<ITelemetry, NoOpTelemetry>();
            }
        }

        private sealed class InfrastructureBuilder(IServiceCollection services) : IInfrastructureBuilder
        {
            /// <summary>
            /// Gets the service collection.
            /// </summary>
            public IServiceCollection Services { get; } = services;
        }
    }
}
