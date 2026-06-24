using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Time
{
    /// <summary>
    /// Provides the real system clock implementation.
    /// </summary>
    public sealed class SystemClock : IClock
    {
        /// <inheritdoc />
        public DateTime UtcNow => DateTime.UtcNow;

        /// <inheritdoc />
        public DateOnly UtcToday => DateOnly.FromDateTime(UtcNow);
    }
}
