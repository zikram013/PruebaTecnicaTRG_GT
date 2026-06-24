using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.TestHost;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    /// <summary>
    /// Public wrapper used by xUnit test classes to access the internal test server fixture from the template.
    /// </summary>
    [SuppressMessage(
        "Maintainability",
        "CA1515:Consider making public types internal",
        Justification = "This type must be public because it is used as an xUnit fixture by public test classes.")]
    public sealed class PublicInfrastructureTestServerFixture : IDisposable
    {
        private readonly GenericInfrastructureTestServerFixture _fixture = new();

        /// <summary>
        /// Gets the test server created by the internal infrastructure fixture.
        /// </summary>
        public TestServer Server => _fixture.Server;

        /// <inheritdoc />
        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}
