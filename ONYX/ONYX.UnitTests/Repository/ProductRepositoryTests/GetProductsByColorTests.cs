using NUnit.Framework;
using ONYX.Api.Domain;
using ONYX.Api.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ONYX.UnitTests.Repository.ProductRepositoryTests
{
    public class GetProductsByColorTests
    {
        private ProductRepository subject;
        private IEnumerable<Product> result;

        [SetUp]
        public void SetUp()
        {
            subject = new ProductRepository();
        }


        [Test]
        public void GivenColorRedExists_WhenGetProductsByColor_ThenReturnProducts()
        {
            result = subject.GetProductsByColor("Red");

            Assert.AreEqual(10, result.ToList().Count);
        }

        [Test]
        public void GivenColorBlackNotExists_WhenGetProductsByColor_ThenReturnEmptyProducts()
        {
            result = subject.GetProductsByColor("Black");

            Assert.AreEqual(0, result.ToList().Count);
        }


    }

}
