using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using ONYX.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ONYX.IntegrationTests.ProductApi
{
    public class HealthCheck
    {

        [Test]
        public async Task WhenGetProductsApiCall_ThenMustReturnUnauthorisedStauts()
        {
            var client = OnyxWebApplicationFactory.CreateClientWithWrongKeyHeader();
            var result = await client.GetAsync("/api/products");

            var responseContent = await result.Content.ReadAsStringAsync();

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));

            Assert.That(responseContent, Is.EqualTo("Api Key is not valid"));
        }

        [Test]
        public async Task WhenGetProductsApiCall_ThenMustReturnOKStatus()
        {
            var client = OnyxWebApplicationFactory.CreateClientWithKeyHeader();
            var result = await client.GetAsync("/api/products");

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
            for (int i = 11; i <= 20; i++)
            {
                var product = new ProductResponseModel
                {
                    Id = i,
                    Color = "Blue",
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                listProductResponeModels.Add(product);
            }

            for (int i = 21; i <= 30; i++)
            {
                var product = new ProductResponseModel
                {
                    Id = i,
                    Color = "Green",
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                listProductResponeModels.Add(product);
            }

            return listProductResponeModels;
        }


    }
}
