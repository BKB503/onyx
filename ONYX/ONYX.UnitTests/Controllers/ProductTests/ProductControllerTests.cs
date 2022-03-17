
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ONYX.Api.Attributes;
using ONYX.Api.Controllers;
using ONYX.Api.Models;
using ONYX.Api.Services;
using ONYX.UnitTests.TestUtils;

using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ONYX.UnitTests.Controllers.ProductTests
{
    public class ProductControllerTests
    {
        private ProductsController subject;
        private Mock<IProductService> productService;
        private List<ProductResponseModel> responseModels;
        private string color = "Red";

        [SetUp]
        public void Setup()
        {
            responseModels = ProductFactory.BuildProductResponseModels().ToList();
            productService = new Mock<IProductService>();
            productService.Setup(x => x.GetProducts()).Returns(responseModels);
            productService.Setup(x => x.GetProductsByColor(color)).Returns(responseModels);

            subject = new ProductsController(productService.Object);
        }

        [Test]
        public void MusHaveHeaderApiKeyAttributeForProductsController()
        {

            var attribute = AttributeChecker.GetClassAttributes(subject, typeof(HeaderApiKeyAttribute)).SingleOrDefault();

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void MusHaveRouteAttributeForProductsController()
        {
            var attribute = AttributeChecker.GetClassAttributes(subject, typeof(RouteAttribute)).SingleOrDefault();

            Assert.That(attribute, Is.Not.Null);

            Assert.That(((RouteAttribute)attribute).Template, Is.EqualTo("api/[controller]"));

        }

        [Test]
        public void MusHaveHttpGetAttributeForGetProducts()
        {
            var attribute = AttributeChecker.GetMethodAttributes(subject, nameof(subject.GetProducts), typeof(HttpGetAttribute)).SingleOrDefault();

            Assert.That(attribute, Is.Not.Null);
        }


        [Test]
        public void MusHaveRouteAttributeForGetProducts()
        {
            var attribute = AttributeChecker.GetMethodAttributes(subject, nameof(subject.GetProducts), typeof(RouteAttribute)).SingleOrDefault();

            Assert.That(attribute, Is.Not.Null);
            Assert.That(((RouteAttribute)attribute).Template, Is.EqualTo(string.Empty));
        }

        [Test]
        public void WhenGetProducts_ThenMustCallService()
        {
            var result = subject.GetProducts();
            // Then
            productService.Verify(m => m.GetProducts(), Times.Once);
        }

        [Test]
        public void WhenProducts_ThenMustReturnOK()
        {
            var result = subject.GetProducts();
            // Then
            Assert.That(((OkObjectResult)result).StatusCode,
                Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public void MusHaveHttpGetAttributeForGetProductsByColor()
        {
            var attribute = AttributeChecker.GetMethodAttributes(subject, nameof(subject.GetProductsByColor), typeof(HttpGetAttribute)).SingleOrDefault();

            Assert.That(attribute, Is.Not.Null);
        }


        [Test]
        public void GivenColorQueryString_WhenGetProductsByColor_ThenMustCallService()
        {

            var result = subject.GetProductsByColor(color);
            // Then
            productService.Verify(m => m.GetProductsByColor(color), Times.Once);
        }

        [Test]
        public void GivenColorQueryString_WhenGetProductsByColor_ThenMustReturnOK()
        {

            var result = subject.GetProductsByColor(color);
            // Then
            Assert.That(((OkObjectResult)result).StatusCode,
                Is.EqualTo((int)HttpStatusCode.OK));
        }
    }
}
