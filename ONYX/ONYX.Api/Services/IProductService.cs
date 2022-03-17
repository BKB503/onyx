using ONYX.Api.Models;

namespace ONYX.Api.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponseModel> GetProducts();
        IEnumerable<ProductResponseModel> GetProductsByColor(string color);
    }
}
