using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Input message for the create vehicle use case.
    /// </summary>
    /// <param name="plate">The vehicle plate.</param>
    /// <param name="brand">The vehicle brand.</param>
    /// <param name="model">The vehicle model.</param>
    /// <param name="manufacturingDate">The vehicle manufacturing date.</param>
    public sealed class CreateVehicleInput(
        string plate,
        string brand,
        string model,
        DateOnly manufacturingDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle plate.
        /// </summary>
        public string Plate { get; } = plate;

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        public string Brand { get; } = brand;

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; } = model;

        /// <summary>
        /// Gets the vehicle manufacturing date.
        /// </summary>
        public DateOnly ManufacturingDate { get; } = manufacturingDate;
    }
}
