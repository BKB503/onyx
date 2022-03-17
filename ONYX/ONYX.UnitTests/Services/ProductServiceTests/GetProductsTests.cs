using Moq;
using NUnit.Framework;
using ONYX.UnitTests.TestUtils;
using ONYX.Api.Domain;
using ONYX.Api.Models;
using ONYX.Api.Repository;
using ONYX.Api.Services;
using System.Collections.Generic;
using System.Linq;

namespace ONYX.UnitTests.Services.ProductServiceTests
{
    public class GetProductsTests
    {
        private ProductService subject;
        private Mock<IProductRepository> productRepository;
        private List<ProductResponseModel> result;
        private List<ProductResponseModel> expectedProductResponses;
        private List<Product> products;

        [SetUp]
        public void SetUp()
        {
            productRepository = new Mock<IProductRepository>();
            products = ProductFactory.BuildProducts().ToList();
            expectedProductResponses = ExpectedProductResponseModels(products);
            productRepository.Setup(x => x.GetProducts()).Returns(products);
            subject = new ProductService(productRepository.Object);
        }

        private List<ProductResponseModel> ExpectedProductResponseModels(List<Product> products)
        {
            var listProductResponeModels = new List<ProductResponseModel>();
            foreach (var product in products)
            {
                var productResponseModel = new ProductResponseModel
                {
                    Id = product.Id,
                    Color = product.Color,
                    Name = product.Name,
                    Description = product.Description
                };
                listProductResponeModels.Add(productResponseModel);
            }
            return listProductResponeModels;
        }

        [Test]
        public void WhenGetProducts_ThenMustCallRepositoryGetProducts()
        {
            subject.GetProducts();

            productRepository.Verify(x => x.GetProducts(), Times.Once);
        }

        [Test]
        public void WhenGetProducts_ThenMustReturnEmptyProductsResponseModel()
        {
            productRepository.Setup(x => x.GetProducts()).Returns(new List<Product>());
            result = subject.GetProducts().ToList();

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void WhenGetProducts_ThenMustReturnProductsResponseModel()
        {
            result = subject.GetProducts().ToList();

            Assert.AreEqual(result.Count, expectedProductResponses.Count);
            for (var i = 0; i < expectedProductResponses.Count(); i++)
            {
                Assert.That(result.ElementAt(i).Description, Is.EqualTo(expectedProductResponses.ElementAt(i).Description));
                Assert.That(result.ElementAt(i).Id, Is.EqualTo(expectedProductResponses.ElementAt(i).Id));
                Assert.That(result.ElementAt(i).Name, Is.EqualTo(expectedProductResponses.ElementAt(i).Name));
                Assert.That(result.ElementAt(i).Color, Is.EqualTo(expectedProductResponses.ElementAt(i).Color));
            }

        }
    }

}
