using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Use case responsible for creating new vehicles in the renting fleet.
    /// </summary>
    /// <param name="clock">The system clock abstraction.</param>
    /// <param name="outputPort">The output port.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    public sealed class CreateVehicleUseCase(
        IClock clock,
        ICreateVehicleOutputPort outputPort,
        IUnitOfWork unitOfWork,
        IVehicleRepository vehicleRepository) : ICreateVehicleUseCase
    {
        private readonly IClock _clock = clock;
        private readonly ICreateVehicleOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <inheritdoc />
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var plate = new Plate(input.Plate);

            if (await _vehicleRepository.ExistsWithPlate(plate).ConfigureAwait(false))
            {
                _outputPort.VehicleAlreadyExistsHandle("A vehicle already exists with the same plate.");
                return;
            }

            var vehicle = Vehicle.Create(
                plate,
                input.Brand,
                input.Model,
                input.ManufacturingDate,
                _clock.UtcToday);

            await _vehicleRepository.Add(vehicle).ConfigureAwait(false);
            await _unitOfWork.Save().ConfigureAwait(false);

            _outputPort.StandardHandle(new CreateVehicleOutput(vehicle));
        }
    }
}
