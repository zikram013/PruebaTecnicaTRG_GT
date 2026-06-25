using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Output returned after a vehicle has been returned.
    /// </summary>
    /// <param name="id">The vehicle identifier.</param>
    /// <param name="status">The vehicle status.</param>
    public sealed class ReturnVehicleOutput(Guid id, string status) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid Id { get; } = id;

        /// <summary>
        /// Gets the vehicle status.
        /// </summary>
        public string Status { get; } = status;
    }
}
