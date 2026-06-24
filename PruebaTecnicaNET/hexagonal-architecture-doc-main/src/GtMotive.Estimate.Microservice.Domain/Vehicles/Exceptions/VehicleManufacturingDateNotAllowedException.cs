using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when the vehicle manufacturing date does not satisfy the fleet business rule.
    /// </summary>
    public sealed class VehicleManufacturingDateNotAllowedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleManufacturingDateNotAllowedException"/> class.
        /// </summary>
        public VehicleManufacturingDateNotAllowedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleManufacturingDateNotAllowedException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public VehicleManufacturingDateNotAllowedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleManufacturingDateNotAllowedException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VehicleManufacturingDateNotAllowedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
