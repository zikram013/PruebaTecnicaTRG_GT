using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when the vehicle is not rented.
    /// </summary>
    public sealed class VehicleIsNotRentedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleIsNotRentedException"/> class.
        /// </summary>
        public VehicleIsNotRentedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleIsNotRentedException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public VehicleIsNotRentedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleIsNotRentedException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VehicleIsNotRentedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
