namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output port for the create vehicle use case.
    /// </summary>
    public interface ICreateVehicleOutputPort : IOutputPortStandard<CreateVehicleOutput>
    {
        /// <summary>
        /// Handles the scenario where a vehicle already exists with the same plate.
        /// </summary>
        /// <param name="message">The error message.</param>
        void VehicleAlreadyExistsHandle(string message);
    }
}
