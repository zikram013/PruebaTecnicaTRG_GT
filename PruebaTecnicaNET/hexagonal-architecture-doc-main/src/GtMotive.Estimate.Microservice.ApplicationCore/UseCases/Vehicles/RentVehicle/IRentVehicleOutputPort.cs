namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Output port for the rent vehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort
    {
        /// <summary>
        /// Handles a successful rent vehicle response.
        /// </summary>
        /// <param name="output">The rent vehicle output.</param>
        void StandardHandle(RentVehicleOutput output);

        /// <summary>
        /// Handles a not found vehicle response.
        /// </summary>
        /// <param name="message">The error message.</param>
        void NotFoundHandle(string message);

        /// <summary>
        /// Handles a customer already having an active rental response.
        /// </summary>
        /// <param name="message">The error message.</param>
        void CustomerAlreadyHasActiveRentalHandle(string message);
    }
}
