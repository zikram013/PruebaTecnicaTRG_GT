using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when the vehicle already rented.
    /// </summary>
    public sealed class VehicleAlreadyRentedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        public VehicleAlreadyRentedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public VehicleAlreadyRentedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VehicleAlreadyRentedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
