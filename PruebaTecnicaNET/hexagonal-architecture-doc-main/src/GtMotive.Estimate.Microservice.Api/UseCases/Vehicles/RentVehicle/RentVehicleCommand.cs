using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Internal command used to send the rent vehicle operation through MediatR.
    /// </summary>
    /// <param name="vehicleId">The vehicle identifier.</param>
    /// <param name="customerId">The customer identifier.</param>
    public sealed class RentVehicleCommand(Guid vehicleId, string customerId) : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public string CustomerId { get; } = customerId ?? throw new ArgumentNullException(nameof(customerId));
    }
}
