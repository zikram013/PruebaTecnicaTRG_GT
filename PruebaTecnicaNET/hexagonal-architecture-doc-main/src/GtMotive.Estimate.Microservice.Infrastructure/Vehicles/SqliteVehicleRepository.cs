using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Vehicles
{
    /// <summary>
    /// Provides a SQLite persistence adapter for vehicles.
    /// </summary>
    public sealed class SqliteVehicleRepository(RentingDbContext context) : IVehicleRepository
    {
        private readonly RentingDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <inheritdoc />
        public async Task Add(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            await _context.Vehicles
                .AddAsync(VehicleEntityMapper.ToEntity(vehicle))
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Vehicle> GetById(VehicleId vehicleId)
        {
            var entity = await _context.Vehicles
                .AsNoTracking()
                .SingleOrDefaultAsync(vehicle => vehicle.Id == vehicleId.Value)
                .ConfigureAwait(false);

            return entity is null ? null : VehicleEntityMapper.ToDomain(entity);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<Vehicle>> GetAvailable()
        {
            var status = VehicleStatus.Available.ToString();

            var entities = await _context.Vehicles
                .AsNoTracking()
                .Where(vehicle => vehicle.Status == status)
                .OrderBy(vehicle => vehicle.Plate)
                .ToListAsync()
                .ConfigureAwait(false);

            return entities
                .Select(VehicleEntityMapper.ToDomain)
                .ToList()
                .AsReadOnly();
        }

        /// <inheritdoc />
        public async Task<bool> ExistsWithPlate(Plate plate)
        {
            var plateText = plate.ToString();

            return await _context.Vehicles
                .AsNoTracking()
                .AnyAsync(vehicle => vehicle.Plate == plateText)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<bool> HasActiveRental(CustomerId customerId)
        {
            var customerIdText = customerId.ToString();
            var rentedStatus = VehicleStatus.Rented.ToString();

            return await _context.Vehicles
                .AsNoTracking()
                .AnyAsync(vehicle =>
                    vehicle.CurrentCustomerId == customerIdText &&
                    vehicle.Status == rentedStatus)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Update(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            var entity = await _context.Vehicles
                .SingleOrDefaultAsync(storedVehicle => storedVehicle.Id == vehicle.Id.Value)
                .ConfigureAwait(false);

            if (entity is null)
            {
                await Add(vehicle).ConfigureAwait(false);
                return;
            }

            entity.Plate = vehicle.Plate.ToString();
            entity.Brand = vehicle.Brand;
            entity.Model = vehicle.Model;
            entity.ManufacturingDate = vehicle.ManufacturingDate;
            entity.Status = vehicle.Status.ToString();
            entity.CurrentCustomerId = vehicle.CurrentCustomerId?.ToString() ?? string.Empty;
        }
    }
}
