#nullable enable

using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents the aggregate root of a vehicle in the renting fleet.
    /// </summary>
    public sealed class Vehicle
    {
        private Vehicle(
            VehicleId id,
            Plate plate,
            string brand,
            string model,
            DateOnly manufacturingDate,
            VehicleStatus status,
            CustomerId? currentCustomerId)
        {
            Id = id;
            Plate = plate;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            Status = status;
            CurrentCustomerId = currentCustomerId;
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public VehicleId Id { get; }

        /// <summary>
        /// Gets the vehicle plate.
        /// </summary>
        public Plate Plate { get; }

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Gets the vehicle manufacturing date.
        /// </summary>
        public DateOnly ManufacturingDate { get; }

        /// <summary>
        /// Gets the current vehicle status.
        /// </summary>
        public VehicleStatus Status { get; private set; }

        /// <summary>
        /// Gets the customer that currently has the vehicle rented.
        /// </summary>
        public CustomerId? CurrentCustomerId { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is available for rental.
        /// </summary>
        public bool IsAvailable => Status == VehicleStatus.Available;

        /// <summary>
        /// Creates a new vehicle and applies the fleet business rules.
        /// </summary>
        /// <param name="plate">The vehicle plate.</param>
        /// <param name="brand">The vehicle brand.</param>
        /// <param name="model">The vehicle model.</param>
        /// <param name="manufacturingDate">The vehicle manufacturing date.</param>
        /// <param name="today">The current date used as reference.</param>
        /// <returns>A new available vehicle.</returns>
        public static Vehicle Create(
            Plate plate,
            string brand,
            string model,
            DateOnly manufacturingDate,
            DateOnly today)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new VehicleBrandShouldNotBeEmptyException("The vehicle brand is required.");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new VehicleModelShouldNotBeEmptyException("The vehicle model is required.");
            }

            var minimumAllowedManufacturingDate = today.AddYears(-5);

            return manufacturingDate switch
            {
                _ when manufacturingDate > today =>
                    throw new VehicleManufacturingDateNotAllowedException("The vehicle manufacturing date cannot be in the future."),

                _ when manufacturingDate < minimumAllowedManufacturingDate =>
                    throw new VehicleManufacturingDateNotAllowedException("The fleet cannot contain vehicles older than 5 years."),

                _ => new Vehicle(
                    VehicleId.New(),
                    plate,
                    brand.Trim(),
                    model.Trim(),
                    manufacturingDate,
                    VehicleStatus.Available,
                    null),
            };
        }

        /// <summary>
        /// Restores an existing vehicle from persistence.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="plate">The vehicle plate.</param>
        /// <param name="brand">The vehicle brand.</param>
        /// <param name="model">The vehicle model.</param>
        /// <param name="manufacturingDate">The vehicle manufacturing date.</param>
        /// <param name="status">The vehicle status.</param>
        /// <param name="currentCustomerId">The current customer identifier.</param>
        /// <returns>The restored vehicle.</returns>
        public static Vehicle Restore(
            VehicleId id,
            Plate plate,
            string brand,
            string model,
            DateOnly manufacturingDate,
            VehicleStatus status,
            CustomerId? currentCustomerId)
        {
            return new Vehicle(
                id,
                plate,
                brand,
                model,
                manufacturingDate,
                status,
                currentCustomerId);
        }

        /// <summary>
        /// Rents the vehicle to a customer.
        /// </summary>
        /// <param name="customerId">The customer that requests the rental.</param>
        public void Rent(CustomerId customerId)
        {
            if (!IsAvailable)
            {
                throw new VehicleAlreadyRentedException("The vehicle is not available for rental.");
            }

            Status = VehicleStatus.Rented;
            CurrentCustomerId = customerId;
        }

        /// <summary>
        /// Returns the vehicle and makes it available again.
        /// </summary>
        public void Return()
        {
            if (Status != VehicleStatus.Rented)
            {
                throw new VehicleIsNotRentedException("The vehicle is not currently rented.");
            }

            Status = VehicleStatus.Available;
            CurrentCustomerId = null;
        }
    }
}
