using System;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// Represents the persistence model for a vehicle.
    /// </summary>
    public sealed class VehicleEntity
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the vehicle plate.
        /// </summary>
        public string Plate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the vehicle brand.
        /// </summary>
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the vehicle manufacturing date.
        /// </summary>
        public DateOnly ManufacturingDate { get; set; }

        /// <summary>
        /// Gets or sets the vehicle status.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current customer identifier.
        /// </summary>
        public string CurrentCustomerId { get; set; } = string.Empty;
    }
}
