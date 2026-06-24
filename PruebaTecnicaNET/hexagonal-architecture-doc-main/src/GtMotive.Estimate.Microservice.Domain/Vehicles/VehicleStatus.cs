namespace GtMotive.Estimate.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Defines the possible statuses of a vehicle in the renting fleet.
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// Defines the possible statuses of a vehicle in the renting fleet.
        /// </summary>
        Available = 0,

        /// <summary>
        /// The vehicle is currently rented by a customer.
        /// </summary>
        Rented = 1,
    }
}
