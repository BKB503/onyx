using ONYX.Api.Domain;

namespace ONYX.Api.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProductsByColor(string color);
    }
}
