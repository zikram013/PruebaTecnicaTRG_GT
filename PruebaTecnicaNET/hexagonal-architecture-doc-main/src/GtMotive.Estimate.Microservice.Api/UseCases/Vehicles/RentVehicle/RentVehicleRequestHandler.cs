using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// MediatR handler that adapts the HTTP request to the rent vehicle use case.
    /// </summary>
    /// <param name="presenter">The presenter.</param>
    /// <param name="useCase">The use case.</param>
    public sealed class RentVehicleRequestHandler(
        RentVehiclePresenter presenter,
        IRentVehicleUseCase useCase) : IRequestHandler<RentVehicleCommand, IWebApiPresenter>
    {
        private readonly RentVehiclePresenter _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        private readonly IRentVehicleUseCase _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));

        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(RentVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            cancellationToken.ThrowIfCancellationRequested();

            var input = new RentVehicleInput(request.VehicleId, request.CustomerId);
            await _useCase.Execute(input).ConfigureAwait(false);

            return _presenter;
        }
    }
}
