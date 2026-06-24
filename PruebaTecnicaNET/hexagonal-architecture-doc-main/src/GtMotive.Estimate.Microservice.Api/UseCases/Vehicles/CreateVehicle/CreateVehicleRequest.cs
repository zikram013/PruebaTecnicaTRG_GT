using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// HTTP request used to create a new vehicle in the fleet.
    /// </summary>
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the vehicle plate.
        /// </summary>
        [Required]
        public string Plate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the vehicle brand.
        /// </summary>
        [Required]
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        [Required]
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the vehicle manufacturing date.
        /// </summary>
        [Required]
        public DateOnly ManufacturingDate { get; set; }
    }
}
