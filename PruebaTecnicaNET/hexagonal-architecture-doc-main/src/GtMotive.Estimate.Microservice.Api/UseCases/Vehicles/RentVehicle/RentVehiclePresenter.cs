using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Presenter that converts the rent vehicle use case output into an HTTP response.
    /// </summary>
    public sealed class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; } = new NoContentResult();

        /// <inheritdoc />
        public void StandardHandle(RentVehicleOutput output)
        {
            ActionResult = new OkObjectResult(new RentVehicleResponse(output));
        }

        /// <inheritdoc />
        public void NotFoundHandle(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found",
                Detail = message,
            };

            ActionResult = new NotFoundObjectResult(problemDetails);
        }

        /// <inheritdoc />
        public void CustomerAlreadyHasActiveRentalHandle(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = message,
            };

            ActionResult = new BadRequestObjectResult(problemDetails);
        }
    }
}
