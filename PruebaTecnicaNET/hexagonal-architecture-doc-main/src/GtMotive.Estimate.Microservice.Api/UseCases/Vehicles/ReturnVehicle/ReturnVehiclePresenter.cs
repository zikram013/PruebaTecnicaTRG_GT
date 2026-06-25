using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Presenter for the return vehicle use case.
    /// </summary>
    public sealed class ReturnVehiclePresenter : IWebApiPresenter, IReturnVehicleOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; } = new EmptyResult();

        /// <inheritdoc />
        public void StandardHandle(ReturnVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            ActionResult = new OkObjectResult(new ReturnVehicleResponse(output.Id, output.Status));
        }

        /// <inheritdoc />
        public void NotFoundHandle(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            ActionResult = new NotFoundObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Vehicle not found",
                Detail = message,
            });
        }

        /// <inheritdoc />
        public void VehicleIsNotRentedHandle(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            ActionResult = new BadRequestObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Vehicle is not rented",
                Detail = message,
            });
        }
    }
}
