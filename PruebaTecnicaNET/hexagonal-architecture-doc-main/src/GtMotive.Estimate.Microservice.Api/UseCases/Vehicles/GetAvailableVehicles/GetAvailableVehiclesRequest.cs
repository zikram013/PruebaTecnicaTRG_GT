using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailableVehicles
{
    /// <summary>
    /// HTTP request used to get available vehicles.
    /// </summary>
    public sealed class GetAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }
}
