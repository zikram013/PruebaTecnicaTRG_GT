using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when the vehicle plate is empty.
    /// </summary>
    public sealed class PlateShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlateShouldNotBeEmptyException"/> class.
        /// </summary>
        public PlateShouldNotBeEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlateShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public PlateShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlateShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public PlateShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
