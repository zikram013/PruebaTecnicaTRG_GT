using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Response returned when a vehicle has been returned.
    /// </summary>
    /// <param name="id">The vehicle identifier.</param>
    /// <param name="status">The vehicle status.</param>
    public sealed class ReturnVehicleResponse(Guid id, string status)
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
