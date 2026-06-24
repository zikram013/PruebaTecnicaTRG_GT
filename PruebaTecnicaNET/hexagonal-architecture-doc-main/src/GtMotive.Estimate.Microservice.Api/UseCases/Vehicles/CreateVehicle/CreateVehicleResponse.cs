using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// HTTP response returned after creating a vehicle.
    /// </summary>
    /// <param name="output">The use case output.</param>
    public sealed class CreateVehicleResponse(CreateVehicleOutput output)
    {
        private readonly CreateVehicleOutput _output = EnsureNotNull(output);

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        [Required]
        public Guid Id => _output.Id;

        /// <summary>
        /// Gets the vehicle plate.
        /// </summary>
        [Required]
        public string Plate => _output.Plate;

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        [Required]
        public string Brand => _output.Brand;

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        [Required]
        public string Model => _output.Model;

        /// <summary>
        /// Gets the vehicle manufacturing date.
        /// </summary>
        [Required]
        public DateOnly ManufacturingDate => _output.ManufacturingDate;

        /// <summary>
        /// Gets the vehicle status.
        /// </summary>
        [Required]
        public string Status => _output.Status;

        private static CreateVehicleOutput EnsureNotNull(CreateVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);
            return output;
        }
    }
}
