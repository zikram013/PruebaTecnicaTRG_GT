using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when the vehicle model is empty.
    /// </summary>
    public sealed class VehicleModelShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleModelShouldNotBeEmptyException"/> class.
        /// </summary>
        public VehicleModelShouldNotBeEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleModelShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public VehicleModelShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleModelShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VehicleModelShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
