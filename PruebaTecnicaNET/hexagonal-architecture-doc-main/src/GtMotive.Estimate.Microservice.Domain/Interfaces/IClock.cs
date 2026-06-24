using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Provides an abstraction over the system clock.
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Gets the current UTC date and time.
        /// </summary>
        DateTime UtcNow { get; }

        /// <summary>
        /// Gets the current UTC date without time information.
        /// </summary>
        DateOnly UtcToday { get; }
    }
}
