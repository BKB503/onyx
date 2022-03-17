using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace ONYX.IntegrationTests.HealthCheckApi
{
    public class HealthCheck
    {


        [Test]
        public async Task WhenHealthCheckApi_ThenMustReturnOKStatus()
        {
            var client = OnyxWebApplicationFactory.CreateClientWithKeyHeader();
            var result = await client.GetAsync("/health");

            var responseContent = await result.Content.ReadAsStringAsync();
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent, Is.EqualTo("Healthy"));
        }

       
    }
}
