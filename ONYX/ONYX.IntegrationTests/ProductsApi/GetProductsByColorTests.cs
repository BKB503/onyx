using NUnit.Framework;
using ONYX.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ONYX.IntegrationTests.ProductApi
{
    public class GetProductsByColorTests
    {

        [Test]
        public async Task WhenGetProductsByColorApiCall_ThenMustReturnUnauthorisedStauts()
        {
            var client = OnyxWebApplicationFactory.CreateClientWithWrongKeyHeader();
            var url = $"/api/products/GetProductsByColor?color=Red";
            var result = await client.GetAsync(url);

            var responseContent = await result.Content.ReadAsStringAsync();

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));

            Assert.That(responseContent, Is.EqualTo("Api Key is not valid"));
        }

        [Test]
        public async Task GivenRedColorExists_WhenGetProductsByColorApiCall_ThenMustReturnOKStatus()
        {
            var client = OnyxWebApplicationFactory.CreateClientWithKeyHeader();
            var url = $"/api/products/GetProductsByColor?color=Red";
            var result = await client.GetAsync(url);

            var productResponse = await result.Content.ReadFromJsonAsync<List<ProductResponseModel>>();
            var expectedProductResponses = ExpectedProductResponseModels();
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(productResponse.ToList().Count, Is.EqualTo(expectedProductResponses.Count));
            for (var i = 0; i < expectedProductResponses.Count(); i++)
            {
                Assert.That(productResponse.ElementAt(i).Description, Is.EqualTo(expectedProductResponses.ElementAt(i).Description));
                Assert.That(productResponse.ElementAt(i).Id, Is.EqualTo(expectedProductResponses.ElementAt(i).Id));
                Assert.That(productResponse.ElementAt(i).Name, Is.EqualTo(expectedProductResponses.ElementAt(i).Name));
                Assert.That(productResponse.ElementAt(i).Color, Is.EqualTo(expectedProductResponses.ElementAt(i).Color));
            }
        }

        [Test]
        public async Task GivenPinkColorNotExists_WhenGetProductsByColorApiCall_ThenMustReturnOKStatus()
        {
            var client = OnyxWebApplicationFactory.CreateClientWithKeyHeader();
            var url = $"/api/products/GetProductsByColor?color=Pink";
            var result = await client.GetAsync(url);

            var productResponse = await result.Content.ReadFromJsonAsync<List<ProductResponseModel>>();

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(productResponse.ToList().Count, Is.EqualTo(0));
        }

        private List<ProductResponseModel> ExpectedProductResponseModels()
        {
            var listProductResponeModels = new List<ProductResponseModel>();

            for (int i = 1; i <= 10; i++)
            {
                var product = new ProductResponseModel
                {
                    Id = i,
                    Color = "Red",
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                listProductResponeModels.Add(product);
            }
          
            return listProductResponeModels;
        }

    }
}
