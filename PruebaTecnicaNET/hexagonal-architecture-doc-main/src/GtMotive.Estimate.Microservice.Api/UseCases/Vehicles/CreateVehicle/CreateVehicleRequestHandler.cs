using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// MediatR handler that adapts the HTTP request to the create vehicle use case.
    /// </summary>
    /// <param name="presenter">The presenter.</param>
    /// <param name="useCase">The use case.</param>
    public sealed class CreateVehicleRequestHandler(
        CreateVehiclePresenter presenter,
        ICreateVehicleUseCase useCase) : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private readonly CreateVehiclePresenter _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        private readonly ICreateVehicleUseCase _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));

        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            cancellationToken.ThrowIfCancellationRequested();

            var input = new CreateVehicleInput(
                request.Plate,
                request.Brand,
                request.Model,
                request.ManufacturingDate);

            await _useCase.Execute(input).ConfigureAwait(false);

            return _presenter;
        }
    }
}
