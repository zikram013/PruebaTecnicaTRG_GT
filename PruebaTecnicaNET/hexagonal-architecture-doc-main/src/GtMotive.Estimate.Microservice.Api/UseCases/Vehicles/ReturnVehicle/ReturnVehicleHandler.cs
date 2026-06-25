using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Handles the return vehicle command.
    /// </summary>
    public sealed class ReturnVehicleHandler(
        IReturnVehicleUseCase useCase,
        ReturnVehiclePresenter presenter) : IRequestHandler<ReturnVehicleCommand, IWebApiPresenter>
    {
        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new ReturnVehicleInput(request.VehicleId)).ConfigureAwait(false);

            return presenter;
        }
    }
}
