using Moq;
using NUnit.Framework;
using ONYX.Api.Repository;
using ONYX.Api.Services;

namespace ONYX.UnitTests.Services.ProductServiceTests
{
    public class ServiceImplementTests
    {
        private ProductService subject;
        private Mock<IProductRepository> productRepository;

        [SetUp]
        public void SetUp()
        {
            productRepository = new Mock<IProductRepository>();
            subject = new ProductService(productRepository.Object);
        }


        [Test]
        public void ImplementsContract()
        {
            Assert.That(subject, Is.InstanceOf(typeof(IProductService)));
        }


    }

}
