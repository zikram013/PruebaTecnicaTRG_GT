using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Provides a no-op unit of work for the in-memory persistence adapter.
    /// </summary>
    public sealed class InMemoryUnitOfWork : IUnitOfWork
    {
        /// <inheritdoc />
        public Task<int> Save()
        {
            return Task.FromResult(0);
        }
    }
}
