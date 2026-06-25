using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailableVehicles
{
    /// <summary>
    /// Output message containing the available vehicles in the fleet.
    /// </summary>
    /// <param name="vehicles">The available vehicles.</param>
    public sealed class GetAvailableVehiclesResponse(
        IReadOnlyCollection<GetAvailableVehiclesOutput> vehicles) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the available vehicles.
        /// </summary>
        public IReadOnlyCollection<GetAvailableVehiclesOutput> Vehicles { get; } = vehicles;
    }
}
