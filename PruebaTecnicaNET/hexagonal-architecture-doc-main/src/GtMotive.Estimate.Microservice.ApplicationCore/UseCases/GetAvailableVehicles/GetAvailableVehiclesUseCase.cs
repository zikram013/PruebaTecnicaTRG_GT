using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// Use case responsible for listing the available vehicles in the fleet.
    /// </summary>
    /// <param name="outputPort">The output port.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    public sealed class GetAvailableVehiclesUseCase(
        IGetAvailableVehiclesOutputPort outputPort,
        IVehicleRepository vehicleRepository) : IGetAvailableVehiclesUseCase
    {
        private readonly IGetAvailableVehiclesOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <inheritdoc />
        public async Task Execute(GetAvailableVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicles = await _vehicleRepository.GetAvailable().ConfigureAwait(false);
            var output = vehicles
                .Select(vehicle => new GetAvailableVehiclesOutput(vehicle))
                .ToList()
                .AsReadOnly();

            _outputPort.StandardHandle(new GetAvailableVehiclesResponse(output));
        }
    }
}
