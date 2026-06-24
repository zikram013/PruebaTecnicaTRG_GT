using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Defines the persistence port for vehicle operations.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a new vehicle to the repository.
        /// </summary>
        /// <param name="vehicle">The vehicle to store.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Add(Vehicle vehicle);

        /// <summary>
        /// Gets a vehicle by its identifier.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>The vehicle if it exists; otherwise, null.</returns>
#nullable enable
        Task<Vehicle?> GetById(VehicleId vehicleId);

        /// <summary>
        /// Gets all available vehicles in the fleet.
        /// </summary>
        /// <returns>The available vehicles.</returns>
        Task<IReadOnlyCollection<Vehicle>> GetAvailable();

        /// <summary>
        /// Checks whether a vehicle already exists with the same plate.
        /// </summary>
        /// <param name="plate">The plate to check.</param>
        /// <returns>A value indicating whether the plate already exists.</returns>
        Task<bool> ExistsWithPlate(Plate plate);

        /// <summary>
        /// Checks whether a customer already has an active rental.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>A value indicating whether the customer has an active rental.</returns>
        Task<bool> HasActiveRental(CustomerId customerId);

        /// <summary>
        /// Updates an existing vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Update(Vehicle vehicle);
    }
}
