using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;

namespace GtMotive.Estimate.Microservice.Infrastructure.Vehicles
{
    /// <summary>
    /// Maps vehicles between domain and persistence models.
    /// </summary>
    internal static class VehicleEntityMapper
    {
        /// <summary>
        /// Maps a domain vehicle to a persistence entity.
        /// </summary>
        /// <param name="vehicle">The domain vehicle.</param>
        /// <returns>The persistence entity.</returns>
        public static VehicleEntity ToEntity(Vehicle vehicle)
        {
            return new VehicleEntity
            {
                Id = vehicle.Id.Value,
                Plate = vehicle.Plate.ToString(),
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                ManufacturingDate = vehicle.ManufacturingDate,
                Status = vehicle.Status.ToString(),
                CurrentCustomerId = vehicle.CurrentCustomerId?.ToString() ?? string.Empty,
            };
        }

        /// <summary>
        /// Maps a persistence entity to a domain vehicle.
        /// </summary>
        /// <param name="entity">The persistence entity.</param>
        /// <returns>The domain vehicle.</returns>
        public static Vehicle ToDomain(VehicleEntity entity)
        {
            var status = Enum.Parse<VehicleStatus>(entity.Status);
            CustomerId? currentCustomerId = string.IsNullOrWhiteSpace(entity.CurrentCustomerId)
                ? null
                : new CustomerId(entity.CurrentCustomerId);

            return Vehicle.Restore(
                VehicleId.From(entity.Id),
                new Plate(entity.Plate),
                entity.Brand,
                entity.Model,
                entity.ManufacturingDate,
                status,
                currentCustomerId);
        }
    }
}
