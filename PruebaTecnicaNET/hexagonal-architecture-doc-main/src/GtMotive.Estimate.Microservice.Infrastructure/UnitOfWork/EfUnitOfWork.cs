using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;

namespace GtMotive.Estimate.Microservice.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Entity Framework unit of work implementation.
    /// </summary>
    public sealed class EfUnitOfWork(RentingDbContext context) : IUnitOfWork
    {
        private readonly RentingDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <inheritdoc />
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
