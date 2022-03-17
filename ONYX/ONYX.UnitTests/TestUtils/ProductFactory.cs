using ONYX.Api.Domain;
using ONYX.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONYX.UnitTests.TestUtils
{
    public static class ProductFactory
    {
        public static IEnumerable<Product> BuildProducts(string color = "Red")
        {
            var products = new List<Product>();

            for (int i = 1; i <= 10; i++)
            {
                var product = new Product
                {
                    Id = i,
                    Color = color,
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                products.Add(product);
            }
            return products;
        }

        public static IEnumerable<ProductResponseModel> BuildProductResponseModels(string color = "Red")
        {
            var products = new List<ProductResponseModel>();

            for (int i = 1; i <= 10; i++)
            {
                var product = new ProductResponseModel
                {
                    Id = i,
                    Color = color,
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                products.Add(product);
            }
            return products;
        }
    }
}
