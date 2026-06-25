using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailableVehicles
{
    /// <summary>
    /// Presenter that converts the available vehicles query output into an HTTP response.
    /// </summary>
    public sealed class GetAvailableVehiclesPresenter : IWebApiPresenter, IGetAvailableVehiclesOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; } = new NoContentResult();

        /// <inheritdoc />
        public void StandardHandle(GetAvailableVehiclesResponse output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var vehicles = new List<VehicleResponse>(output.Vehicles.Count);

            foreach (var vehicle in output.Vehicles)
            {
                vehicles.Add(new VehicleResponse(vehicle));
            }

            ActionResult = new OkObjectResult(vehicles.AsReadOnly());
        }
    }
}
