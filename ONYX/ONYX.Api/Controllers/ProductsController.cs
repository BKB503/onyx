using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ONYX.Api.Services;
using ONYX.Api.Attributes;

namespace ONYX.Api.Controllers
{

    [HeaderApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetProducts()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("GetProductsByColor")]
        // [Route("GetProductsByColor/{color}", Name = "GetProductsByColor")]
        public IActionResult GetProductsByColor([FromQuery] string color)
        {
            var products = productService.GetProductsByColor(color);
            return Ok(products);
        }

    }
}
