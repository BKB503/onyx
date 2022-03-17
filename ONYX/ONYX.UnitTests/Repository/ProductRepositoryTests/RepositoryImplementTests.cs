using NUnit.Framework;
using ONYX.Api.Repository;

namespace ONYX.UnitTests.Repository.ProductRepositoryTests
{
    public class RepositoryImplementTests
    {
        private ProductRepository subject;

        [SetUp]
        public void SetUp()
        {
            subject = new ProductRepository();
        }


        [Test]
        public void ImplementsContract()
        {
            Assert.That(subject, Is.InstanceOf(typeof(IProductRepository)));
        }


    }

}
