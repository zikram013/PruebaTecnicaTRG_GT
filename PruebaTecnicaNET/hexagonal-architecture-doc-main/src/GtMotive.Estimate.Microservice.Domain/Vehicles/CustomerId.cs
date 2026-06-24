using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents the external identifier of a customer.
    /// </summary>
    public readonly struct CustomerId : IEquatable<CustomerId>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerId"/> struct.
        /// </summary>
        /// <param name="value">The customer identifier value.</param>
        public CustomerId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new CustomerIdShouldNotBeEmptyException("The customer identifier is required.");
            }

            _value = value.Trim();
        }

        /// <summary>
        /// Compares the current customer identifier with another customer identifier.
        /// </summary>
        /// <param name="other">The customer identifier to compare.</param>
        /// <returns>A value indicating whether both customer identifiers are equal.</returns>
        public bool Equals(CustomerId other)
        {
            return string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is CustomerId other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(_value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return _value;
        }
    }
}
