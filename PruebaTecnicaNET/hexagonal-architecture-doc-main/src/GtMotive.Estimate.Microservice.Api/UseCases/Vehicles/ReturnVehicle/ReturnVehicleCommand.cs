using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Command used to return a rented vehicle.
    /// </summary>
    /// <param name="vehicleId">The vehicle identifier.</param>
    public sealed class ReturnVehicleCommand(Guid vehicleId) : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;
    }
}
