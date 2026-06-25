using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Use case responsible for renting an available vehicle to a customer.
    /// </summary>
    /// <param name="outputPort">The output port.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    public sealed class RentVehicleUseCase(
        IRentVehicleOutputPort outputPort,
        IUnitOfWork unitOfWork,
        IVehicleRepository vehicleRepository) : IRentVehicleUseCase
    {
        private readonly IRentVehicleOutputPort _outputPort = outputPort;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <inheritdoc />
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicleId = VehicleId.From(input.VehicleId);
            var customerId = new CustomerId(input.CustomerId);
            var vehicle = await _vehicleRepository.GetById(vehicleId).ConfigureAwait(false);

            if (vehicle is null)
            {
                _outputPort.NotFoundHandle("The requested vehicle was not found.");
                return;
            }

            if (await _vehicleRepository.HasActiveRental(customerId).ConfigureAwait(false))
            {
                _outputPort.CustomerAlreadyHasActiveRentalHandle("The customer already has an active vehicle rental.");
                return;
            }

            vehicle.Rent(customerId);

            await _vehicleRepository.Update(vehicle).ConfigureAwait(false);
            await _unitOfWork.Save().ConfigureAwait(false);

            _outputPort.StandardHandle(new RentVehicleOutput(vehicle));
        }
    }
}
