using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// Represents an available vehicle in the use case output.
    /// </summary>
    public sealed class GetAvailableVehiclesOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicle">The available vehicle.</param>
        public GetAvailableVehiclesOutput(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            Id = vehicle.Id.Value;
            Plate = vehicle.Plate.ToString();
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            ManufacturingDate = vehicle.ManufacturingDate;
            Status = vehicle.Status.ToString();
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the vehicle plate.
        /// </summary>
        public string Plate { get; }

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Gets the vehicle manufacturing date.
        /// </summary>
        public DateOnly ManufacturingDate { get; }

        /// <summary>
        /// Gets the vehicle status.
        /// </summary>
        public string Status { get; }
    }
}
