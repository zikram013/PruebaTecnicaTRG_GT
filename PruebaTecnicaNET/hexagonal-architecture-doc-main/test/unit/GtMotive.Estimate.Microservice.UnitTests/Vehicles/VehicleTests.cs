using System;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Vehicles
{
    /// <summary>
    /// Unit tests for the vehicle aggregate.
    /// </summary>
    public sealed class VehicleTests
    {
        /// <summary>
        /// Ensures that vehicles older than five years cannot be created.
        /// </summary>
        [Fact]
        public void CreateShouldFailWhenManufacturingDateIsOlderThanFiveYears()
        {
            var today = new DateOnly(2026, 6, 24);
            var manufacturingDate = today.AddYears(-5).AddDays(-1);

            Action action = () => Vehicle.Create(
                new Plate("1234ABC"),
                "Toyota",
                "Corolla",
                manufacturingDate,
                today);

            action.Should().Throw<VehicleManufacturingDateNotAllowedException>()
                .WithMessage("*5 years*");
        }
    }
}
