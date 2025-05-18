using Microsoft.AspNetCore.Mvc;
using Product.Domain.Interfaces;
using Product.Domain.Models;

namespace Product.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IProductService _productService;

        public ProductController(
        ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }


        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product.Domain.Models.Product>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet]
        public async Task<ActionResult<Product.Domain.Models.Product>> GetProduct(int id)
        {
            Product.Domain.Models.Product? product = await _productService.GetProduct(id);

            if(product == null)
                return NotFound();
            
            return Ok(product);
        }


        [HttpPut]
        public async Task<IActionResult> CreateProduct(CreateProduct product)
        {
            if (product == null)
                return BadRequest();


            if (await _productService.ProductExistByProductCode(product.ProductCode))
                return BadRequest("Product with this product code already exists.");

            await _productService.CreateProduct(product);

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateStockAsync(int productId, int newStock)
        {

            if (newStock <= 0)
                return BadRequest("Stock cannot be lower than 0");

            if (productId < 0)
                return BadRequest("Product id cannot be lower than 0");


            if (!await _productService.ProductExistById(productId))
                return BadRequest("Product not found");

            await _productService.UpdateStockAsync(productId, newStock);

            return Ok(null);
        }
    }
}
