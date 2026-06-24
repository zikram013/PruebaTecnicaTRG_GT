using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs.Vehicles
{
    /// <summary>
    /// Infrastructure tests for the vehicles controller at host level.
    /// </summary>
    public sealed class VehiclesControllerTests(PublicInfrastructureTestServerFixture fixture)
        : IClassFixture<PublicInfrastructureTestServerFixture>
    {
        /// <summary>
        /// Ensures that the create vehicle endpoint returns bad request when required fields are missing.
        /// </summary>
        /// <returns>A task that represents the asynchronous test operation.</returns>
        [Fact]
        public async Task PostShouldReturnBadRequestWhenRequiredFieldsAreMissing()
        {
            using var client = fixture.Server.CreateClient();
            using var content = new StringContent("{}", Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                new Uri("/api/vehicles", UriKind.Relative),
                content).ConfigureAwait(true);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
