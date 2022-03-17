using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ONYX.IntegrationTests
{
    public static class OnyxWebApplicationFactory
    {
        public static HttpClient CreateClientWithKeyHeader()
        {
            var apiKey = "859B5417-C7EA-4A9C-9346-9AC5BF6A5086";
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {

                builder.ConfigureServices(s =>
                {

                });
            });

            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
            return client;
        }

        public static HttpClient CreateClientWithWrongKeyHeader()
        {
            var apiKey = "fff";
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {

                builder.ConfigureServices(s =>
                {

                });
            });

            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
            return client;
        }
    }
}
