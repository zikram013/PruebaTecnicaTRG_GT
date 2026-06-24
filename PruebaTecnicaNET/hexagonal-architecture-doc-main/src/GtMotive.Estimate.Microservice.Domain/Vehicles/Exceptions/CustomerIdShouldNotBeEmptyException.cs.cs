using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when Customer Id is empty.
    /// </summary>
    public sealed class CustomerIdShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerIdShouldNotBeEmptyException"/> class.
        /// </summary>
        public CustomerIdShouldNotBeEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerIdShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public CustomerIdShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerIdShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CustomerIdShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
