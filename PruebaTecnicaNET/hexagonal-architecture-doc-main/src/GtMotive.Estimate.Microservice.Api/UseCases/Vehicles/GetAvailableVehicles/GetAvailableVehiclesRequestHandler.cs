using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailableVehicles
{
    /// <summary>
    /// MediatR handler that adapts the HTTP request to the available vehicles query use case.
    /// </summary>
    /// <param name="presenter">The presenter.</param>
    /// <param name="useCase">The use case.</param>
    public sealed class GetAvailableVehiclesRequestHandler(
        GetAvailableVehiclesPresenter presenter,
        IGetAvailableVehiclesUseCase useCase) : IRequestHandler<GetAvailableVehiclesRequest, IWebApiPresenter>
    {
        private readonly GetAvailableVehiclesPresenter _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        private readonly IGetAvailableVehiclesUseCase _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));

        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(GetAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            cancellationToken.ThrowIfCancellationRequested();

            await _useCase.Execute(new GetAvailableVehiclesInput()).ConfigureAwait(false);

            return _presenter;
        }
    }
}
