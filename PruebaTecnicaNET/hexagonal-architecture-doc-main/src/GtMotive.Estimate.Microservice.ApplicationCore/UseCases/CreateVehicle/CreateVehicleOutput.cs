using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output message for the create vehicle use case.
    /// </summary>
    public sealed class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicle">The created vehicle.</param>
        public CreateVehicleOutput(Vehicle vehicle)
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
