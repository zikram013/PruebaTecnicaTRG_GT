using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Input data required to return a rented vehicle.
    /// </summary>
    /// <param name="vehicleId">The vehicle identifier.</param>
    public sealed class ReturnVehicleInput(Guid vehicleId) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;
    }
}
