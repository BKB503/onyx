using ONYX.Api.Domain;
using ONYX.Api.Models;
using ONYX.Api.Repository;

namespace ONYX.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<ProductResponseModel> GetProducts()
        {
            var products = productRepository.GetProducts();
            if (!products.Any())
            {
                return new List<ProductResponseModel>();
            }
            var productResponseModels = MapProducts(products);

            return productResponseModels;
        }

        public IEnumerable<ProductResponseModel> GetProductsByColor(string color)
        {
            var products = productRepository.GetProductsByColor(color);
            if (!products.Any())
            {
                return new List<ProductResponseModel>();
            }

            var productResponseModels = MapProducts(products);
            return productResponseModels;
        }

        private IEnumerable<ProductResponseModel> MapProducts(IEnumerable<Product> products)
        {
            var productResponseModels = products.Select(x => new ProductResponseModel
            {
                Color = x.Color,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,

            });
            return productResponseModels;
        }
    }
}
