#nullable enable

using System;
using System.Globalization;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents a vehicle plate.
    /// </summary>
    public readonly struct Plate : IEquatable<Plate>
    {
        private readonly string? _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Plate"/> struct.
        /// </summary>
        /// <param name="value">The plate text.</param>
        public Plate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new PlateShouldNotBeEmptyException("The vehicle plate is required.");
            }

            _value = value.Trim().ToUpper(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Determines whether two plates are equal.
        /// </summary>
        /// <param name="left">The first plate to compare.</param>
        /// <param name="right">The second plate to compare.</param>
        /// <returns>A value indicating whether both plates are equal.</returns>
        public static bool operator ==(Plate left, Plate right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two plates are different.
        /// </summary>
        /// <param name="left">The first plate to compare.</param>
        /// <param name="right">The second plate to compare.</param>
        /// <returns>A value indicating whether both plates are different.</returns>
        public static bool operator !=(Plate left, Plate right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Compares the current plate with another plate.
        /// </summary>
        /// <param name="other">The plate to compare.</param>
        /// <returns>A value indicating whether both plates are equal.</returns>
        public bool Equals(Plate other)
        {
            return string.Equals(_value, other._value, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is Plate other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _value is null ? 0 : StringComparer.Ordinal.GetHashCode(_value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return _value ?? string.Empty;
        }
    }
}
