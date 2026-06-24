using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs.Vehicles
{
    /// <summary>
    /// Functional tests for the rent vehicle use case without using the HTTP host.
    /// </summary>
    [SuppressMessage(
        "Maintainability",
        "CA1515:Consider making public types internal",
        Justification = "xUnit test classes must be public to be discovered by the test runner.")]
    public sealed class RentVehicleUseCaseTests(PublicCompositionRootTestFixture fixture)
        : IClassFixture<PublicCompositionRootTestFixture>
    {
        /// <summary>
        /// Ensures that the same customer cannot rent more than one vehicle at the same time.
        /// </summary>
        /// <returns>A task that represents the asynchronous test operation.</returns>
        [Fact]
        public async Task RentVehicleShouldFailWhenCustomerAlreadyHasActiveRental()
        {
            var today = new DateOnly(2026, 6, 24);
            Vehicle firstVehicle = null!;
            Vehicle secondVehicle = null!;

            await fixture.UsingRepository<IVehicleRepository>(async repository =>
            {
                firstVehicle = Vehicle.Create(new Plate("1111AAA"), "Toyota", "Corolla", today, today);
                secondVehicle = Vehicle.Create(new Plate("2222BBB"), "Ford", "Focus", today, today);

                await repository.Add(firstVehicle).ConfigureAwait(true);
                await repository.Add(secondVehicle).ConfigureAwait(true);
            }).ConfigureAwait(true);

            await fixture.UsingHandlerForRequestResponse<RentVehicleCommand, IWebApiPresenter>(async handler =>
            {
                var firstPresenter = await RentVehicle(
                    handler,
                    firstVehicle.Id.Value,
                    "customer-001").ConfigureAwait(true);

                firstPresenter.ActionResult.Should().BeOfType<OkObjectResult>();
            }).ConfigureAwait(true);

            await fixture.UsingHandlerForRequestResponse<RentVehicleCommand, IWebApiPresenter>(async handler =>
            {
                var secondPresenter = await RentVehicle(
                    handler,
                    secondVehicle.Id.Value,
                    "customer-001").ConfigureAwait(true);

                secondPresenter.ActionResult.Should().BeOfType<BadRequestObjectResult>();
            }).ConfigureAwait(true);
        }

        private static async Task<IWebApiPresenter> RentVehicle(
            IRequestHandler<RentVehicleCommand, IWebApiPresenter> handler,
            Guid vehicleId,
            string customerId)
        {
            return await handler.Handle(
                new RentVehicleCommand(vehicleId, customerId),
                CancellationToken.None).ConfigureAwait(true);
        }
    }
}
