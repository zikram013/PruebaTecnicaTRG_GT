using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input message for the rent vehicle use case.
    /// </summary>
    /// <param name="vehicleId">The vehicle identifier.</param>
    /// <param name="customerId">The customer identifier.</param>
    public sealed class RentVehicleInput(Guid vehicleId, string customerId) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public string CustomerId { get; } = customerId;
    }
}
