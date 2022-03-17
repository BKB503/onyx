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
    public class GetProductsByColorTests
    {
        private ProductService subject;
        private Mock<IProductRepository> productRepository;
        private List<ProductResponseModel> result;
        private List<ProductResponseModel> expectedProductResponses;
        private List<Product> products;
        private string color = "Green";

        [SetUp]
        public void SetUp()
        {
            productRepository = new Mock<IProductRepository>();
            products = ProductFactory.BuildProducts(color).ToList();
            expectedProductResponses = ExpectedProductResponseModels(products);
            productRepository.Setup(x => x.GetProductsByColor(color)).Returns(products);
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
        public void GivenColor_WhenGetProductsByColor_ThenMustCallRepositoryGetProducts()
        {
            subject.GetProductsByColor(color);

            productRepository.Verify(x => x.GetProductsByColor(color), Times.Once);
        }

        [Test]
        public void GivenColor_WhenGetProductsByColor_ThenMustReturnEmptyProductsResponseModel()
        {
            productRepository.Setup(x => x.GetProductsByColor(color)).Returns(new List<Product>());
            result = subject.GetProductsByColor(color).ToList();

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GivenColorNotExists_WhenGetProductsByColor_ThenMustReturnEmptyProductsResponseModel()
        {
            productRepository.Setup(x => x.GetProductsByColor(color)).Returns(new List<Product>());
            result = subject.GetProductsByColor("Unknown").ToList();

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GivenColor_WhenGetProductsByColor_ThenMustReturnProductsResponseModel()
        {
            result = subject.GetProductsByColor(color).ToList();

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
