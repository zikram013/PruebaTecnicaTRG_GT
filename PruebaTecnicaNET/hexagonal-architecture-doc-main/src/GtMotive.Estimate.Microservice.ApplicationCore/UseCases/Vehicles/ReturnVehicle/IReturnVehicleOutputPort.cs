namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Output port used by the return vehicle use case.
    /// </summary>
    public interface IReturnVehicleOutputPort :
        IOutputPortStandard<ReturnVehicleOutput>,
        IOutputPortNotFound
    {
        /// <summary>
        /// Handles the case where the vehicle is not currently rented.
        /// </summary>
        /// <param name="message">The error message.</param>
        void VehicleIsNotRentedHandle(string message);
    }
}
