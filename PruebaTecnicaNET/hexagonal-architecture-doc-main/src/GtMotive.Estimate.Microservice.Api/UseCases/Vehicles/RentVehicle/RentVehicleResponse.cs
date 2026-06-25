using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// HTTP response returned after renting a vehicle.
    /// </summary>
    /// <param name="output">The use case output.</param>
    public sealed class RentVehicleResponse(RentVehicleOutput output)
    {
        private readonly RentVehicleOutput _output = output ?? throw new ArgumentNullException(nameof(output));

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        [Required]
        public Guid VehicleId => _output.VehicleId;

        /// <summary>
        /// Gets the vehicle plate.
        /// </summary>
        [Required]
        public string Plate => _output.Plate;

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        [Required]
        public string CustomerId => _output.CustomerId;

        /// <summary>
        /// Gets the vehicle status.
        /// </summary>
        [Required]
        public string Status => _output.Status;
    }
}
