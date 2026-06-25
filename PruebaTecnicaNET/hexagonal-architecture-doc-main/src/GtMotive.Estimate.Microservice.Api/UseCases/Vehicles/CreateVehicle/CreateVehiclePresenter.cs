using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Presenter that converts the create vehicle use case output into an HTTP response.
    /// </summary>
    public sealed class CreateVehiclePresenter : IWebApiPresenter, ICreateVehicleOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; } = new NoContentResult();

        /// <inheritdoc />
        public void StandardHandle(CreateVehicleOutput response)
        {
            var viewModel = new CreateVehicleResponse(response);
            ActionResult = new CreatedResult($"/api/vehicles/{viewModel.Id}", viewModel);
        }

        /// <inheritdoc />
        public void VehicleAlreadyExistsHandle(string message)
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
