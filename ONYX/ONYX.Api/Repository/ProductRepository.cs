using ONYX.Api.Domain;

namespace ONYX.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            return Products();
        }

        public IEnumerable<Product> GetProductsByColor(string color)
        {
            return Products().Where(x => x.Color.ToLower() == color.ToLower());
        }

        private List<Product> Products()
        {
            var products = new List<Product>();

            for (int i = 1; i <= 10; i++)
            {
                var product = new Product
                {
                    Id = i,
                    Color = "Red",
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                products.Add(product);
            }
            for (int i = 11; i <= 20; i++)
            {
                var product = new Product
                {
                    Id = i,
                    Color = "Blue",
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                products.Add(product);
            }

            for (int i = 21; i <= 30; i++)
            {
                var product = new Product
                {
                    Id = i,
                    Color = "Green",
                    Name = $"Product Name {i}",
                    Description = $"Product Description {i}"
                };
                products.Add(product);
            }

            return products;
        }
    }
}
