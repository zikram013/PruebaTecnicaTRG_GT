using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Exceptions;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Handles the return of a rented vehicle.
    /// </summary>
    public sealed class ReturnVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IUnitOfWork unitOfWork,
        IReturnVehicleOutputPort outputPort) : IReturnVehicleUseCase
    {
        /// <inheritdoc />
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicleId = VehicleId.From(input.VehicleId);

            var vehicle = await vehicleRepository.GetById(vehicleId).ConfigureAwait(false);

            if (vehicle is null)
            {
                outputPort.NotFoundHandle("Vehicle not found.");
                return;
            }

            try
            {
                vehicle.Return();
            }
            catch (VehicleIsNotRentedException exception)
            {
                outputPort.VehicleIsNotRentedHandle(exception.Message);
                return;
            }

            await vehicleRepository.Update(vehicle).ConfigureAwait(false);
            await unitOfWork.Save().ConfigureAwait(false);

            outputPort.StandardHandle(
                new ReturnVehicleOutput(
                    vehicle.Id.Value,
                    vehicle.Status.ToString()));
        }
    }
}
