using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ReturnVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(serviceProvider => serviceProvider.GetRequiredService<CreateVehiclePresenter>());

            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort>(serviceProvider => serviceProvider.GetRequiredService<RentVehiclePresenter>());

            services.AddScoped<GetAvailableVehiclesPresenter>();
            services.AddScoped<IGetAvailableVehiclesOutputPort>(serviceProvider => serviceProvider.GetRequiredService<GetAvailableVehiclesPresenter>());

            services.AddScoped<ReturnVehiclePresenter>();
            services.AddScoped<IReturnVehicleOutputPort>(provider => provider.GetRequiredService<ReturnVehiclePresenter>());

            return services;
        }
    }
}
