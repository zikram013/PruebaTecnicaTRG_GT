using System;
using System.Globalization;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents the domain identifier of a vehicle.
    /// </summary>
    public readonly struct VehicleId : IEquatable<VehicleId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleId"/> struct.
        /// </summary>
        /// <param name="value">The vehicle identifier value.</param>
        public VehicleId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new VehicleIdShouldNotBeEmptyException("The vehicle identifier cannot be empty.");
            }

            Value = value;
        }

        /// <summary>
        /// Gets the vehicle identifier value.
        /// </summary>
        public Guid Value { get; }

        /// <summary>
        /// Determines whether two vehicle identifiers are equal.
        /// </summary>
        /// <param name="left">The first vehicle identifier.</param>
        /// <param name="right">The second vehicle identifier.</param>
        /// <returns>A value indicating whether both vehicle identifiers are equal.</returns>
        public static bool operator ==(VehicleId left, VehicleId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two vehicle identifiers are different.
        /// </summary>
        /// <param name="left">The first vehicle identifier.</param>
        /// <param name="right">The second vehicle identifier.</param>
        /// <returns>A value indicating whether both vehicle identifiers are different.</returns>
        public static bool operator !=(VehicleId left, VehicleId right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Creates a new vehicle identifier.
        /// </summary>
        /// <returns>A new vehicle identifier.</returns>
        public static VehicleId New()
        {
            return new VehicleId(Guid.NewGuid());
        }

        /// <summary>
        /// Creates a vehicle identifier from an existing <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The identifier value.</param>
        /// <returns>A vehicle identifier.</returns>
        public static VehicleId From(Guid value)
        {
            return new VehicleId(value);
        }

        /// <summary>
        /// Compares the current identifier with another vehicle identifier.
        /// </summary>
        /// <param name="other">The vehicle identifier to compare.</param>
        /// <returns>A value indicating whether both identifiers are equal.</returns>
        public bool Equals(VehicleId other)
        {
            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is VehicleId other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value.ToString("D", CultureInfo.InvariantCulture);
        }
    }
}
