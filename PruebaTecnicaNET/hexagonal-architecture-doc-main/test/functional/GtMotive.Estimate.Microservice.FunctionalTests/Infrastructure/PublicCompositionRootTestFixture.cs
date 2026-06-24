using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MediatR;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    /// <summary>
    /// Public wrapper used by xUnit test classes to access the internal composition root fixture from the template.
    /// </summary>
    [SuppressMessage(
        "Maintainability",
        "CA1515:Consider making public types internal",
        Justification = "This type must be public because it is used as an xUnit fixture by public test classes.")]
    public sealed class PublicCompositionRootTestFixture : IDisposable
    {
        private readonly CompositionRootTestFixture _fixture = new();
        private bool _disposed;

        /// <summary>
        /// Executes an action using a repository resolved from the composition root.
        /// </summary>
        /// <typeparam name="TRepository">The repository type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task UsingRepository<TRepository>(Func<TRepository, Task> action)
            where TRepository : class
        {
            ObjectDisposedException.ThrowIf(_disposed, this);

            return _fixture.UsingRepository(action);
        }

        /// <summary>
        /// Executes an action using a MediatR request handler resolved from the composition root.
        /// </summary>
        /// <typeparam name="TRequest">The request type.</typeparam>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task UsingHandlerForRequestResponse<TRequest, TResponse>(
            Func<IRequestHandler<TRequest, TResponse>, Task> action)
            where TRequest : IRequest<TResponse>
        {
            ObjectDisposedException.ThrowIf(_disposed, this);

            return _fixture.UsingHandlerForRequestResponse(action);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _fixture.Dispose();
            _disposed = true;

            GC.SuppressFinalize(this);
        }
    }
}
