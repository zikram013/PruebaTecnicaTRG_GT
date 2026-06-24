using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Exception thrown when the vehicle id is empty.
    /// </summary>
    public sealed class VehicleIdShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleIdShouldNotBeEmptyException"/> class.
        /// </summary>
        public VehicleIdShouldNotBeEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleIdShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public VehicleIdShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleIdShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VehicleIdShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    {
    }
}
