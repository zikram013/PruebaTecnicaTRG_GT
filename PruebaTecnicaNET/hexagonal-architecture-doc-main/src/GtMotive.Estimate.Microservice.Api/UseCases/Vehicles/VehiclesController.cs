using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// REST controller for renting fleet vehicle operations.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    [ApiController]
    [AllowAnonymous]
    [Route("api/vehicles")]
    public sealed class VehiclesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        /// <summary>
        /// Creates a new vehicle in the fleet.
        /// </summary>
        /// <param name="request">The vehicle creation request.</param>
        /// <returns>The HTTP action result.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var presenter = await _mediator.Send(request).ConfigureAwait(false);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Gets the available vehicles in the fleet.
        /// </summary>
        /// <returns>The HTTP action result.</returns>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var presenter = await _mediator.Send(new GetAvailableVehiclesRequest()).ConfigureAwait(false);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Rents an available vehicle to a customer.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="request">The rent vehicle request.</param>
        /// <returns>The HTTP action result.</returns>
        [HttpPost("{vehicleId:guid}/rentals")]
        public async Task<IActionResult> Rent(Guid vehicleId, [FromBody] RentVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var command = new RentVehicleCommand(vehicleId, request.CustomerId);
            var presenter = await _mediator.Send(command).ConfigureAwait(false);

            return presenter.ActionResult;
        }
    }
}
