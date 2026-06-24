#nullable enable

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Infrastructure.Vehicles
{
    /// <summary>
    /// In-memory implementation of the vehicle repository.
    /// </summary>
    public sealed class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly ConcurrentDictionary<Guid, Vehicle> _vehicles = new();

        /// <inheritdoc />
        public Task Add(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            _vehicles.TryAdd(vehicle.Id.Value, vehicle);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<Vehicle?> GetById(VehicleId vehicleId)
        {
            _vehicles.TryGetValue(vehicleId.Value, out var vehicle);
            return Task.FromResult(vehicle);
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Vehicle>> GetAvailable()
        {
            IReadOnlyCollection<Vehicle> availableVehicles =
            [
                .. _vehicles.Values
            .Where(vehicle => vehicle.IsAvailable)
            .OrderBy(vehicle => vehicle.Plate.ToString())
            ];

            return Task.FromResult(availableVehicles);
        }

        /// <inheritdoc />
        public Task<bool> ExistsWithPlate(Plate plate)
        {
            var exists = _vehicles.Values.Any(vehicle => vehicle.Plate.Equals(plate));
            return Task.FromResult(exists);
        }

        /// <inheritdoc />
        public Task<bool> HasActiveRental(CustomerId customerId)
        {
            var exists = _vehicles.Values.Any(vehicle =>
                vehicle.CurrentCustomerId.HasValue && vehicle.CurrentCustomerId.Value.Equals(customerId));

            return Task.FromResult(exists);
        }

        /// <inheritdoc />
        public Task Update(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            _vehicles[vehicle.Id.Value] = vehicle;
            return Task.CompletedTask;
        }
    }
}
