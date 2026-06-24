using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output message for the rent vehicle use case.
    /// </summary>
    public sealed class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicle">The rented vehicle.</param>
        public RentVehicleOutput(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            VehicleId = vehicle.Id.Value;
            Plate = vehicle.Plate.ToString();
            CustomerId = vehicle.CurrentCustomerId?.ToString() ?? string.Empty;
            Status = vehicle.Status.ToString();
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the vehicle plate.
        /// </summary>
        public string Plate { get; }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public string CustomerId { get; }

        /// <summary>
        /// Gets the vehicle status.
        /// </summary>
        public string Status { get; }
    }
}
