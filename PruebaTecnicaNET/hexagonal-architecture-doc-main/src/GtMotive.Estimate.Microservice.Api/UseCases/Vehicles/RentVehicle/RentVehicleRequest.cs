using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// HTTP request body used to rent a vehicle.
    /// </summary>
    public sealed class RentVehicleRequest
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Required]
        public string CustomerId { get; set; } = string.Empty;
    }
}
