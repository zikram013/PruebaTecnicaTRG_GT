using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// HTTP request for creating a vehicle.
    /// </summary>
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets the vehicle plate.
        /// </summary>
        [Required]
        public string Plate { get; init; } = string.Empty;

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        [Required]
        public string Brand { get; init; } = string.Empty;

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        [Required]
        public string Model { get; init; } = string.Empty;

        /// <summary>
        /// Gets the vehicle manufacturing date.
        /// </summary>
        [Required]
        [JsonRequired]
        public DateOnly ManufacturingDate { get; init; }
    }
}
