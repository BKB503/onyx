using NUnit.Framework;
using ONYX.Api.Domain;
using ONYX.Api.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ONYX.UnitTests.Repository.ProductRepositoryTests
{
    public class GetProductsTests
    {
        private ProductRepository subject;
        private IEnumerable<Product> result;

        [SetUp]
        public void SetUp()
        {
            subject = new ProductRepository();
        }


        [Test]
        public void WhenGetProducts_ThenReturnProducts()
        {
            result = subject.GetProducts();

            Assert.AreEqual(30, result.ToList().Count);
        }


    }

}
