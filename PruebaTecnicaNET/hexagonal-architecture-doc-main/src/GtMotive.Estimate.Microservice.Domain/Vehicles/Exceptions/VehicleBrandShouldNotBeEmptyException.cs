using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when the vehicle brand is empty.
    /// </summary>
    public sealed class VehicleBrandShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleBrandShouldNotBeEmptyException"/> class.
        /// </summary>
        public VehicleBrandShouldNotBeEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleBrandShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public VehicleBrandShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleBrandShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VehicleBrandShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
