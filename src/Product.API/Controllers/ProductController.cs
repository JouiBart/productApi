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
        private readonly IProductCacheService _productService;

        public ProductController(
        ILogger<ProductController> logger, IProductCacheService productService)
        {
            _logger = logger;
            _productService = productService;
        }



        /// <summary>
        /// Get all products.
        /// </summary>
        /// <response code="200">List of all products</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product.Domain.Models.Product>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">id of product</param>
        /// <response code="200">Single product</response>
        /// <response code="404">Product not exist</response>
        [HttpGet]
        public async Task<ActionResult<Product.Domain.Models.Product>> GetProduct(int id)
        {
            Product.Domain.Models.Product? product = await _productService.GetProduct(id);

            if(product == null)
                return NotFound();
            
            return Ok(product);
        }


        /// <summary>
        /// Create new product.
        /// </summary>
        /// <param name="product"></param>
        /// <response code="200">Product was created</response>
        /// <response code="400">Product was not created because of bad parameters or because the product is already exist</response>
        [HttpPut]
        public async Task<IActionResult> CreateProduct(CreateProduct product)
        {
            if (product == null)
                return BadRequest("Product cannot be null");


            if (await _productService.ProductExistByProductCode(product.ProductCode))
                return BadRequest("Product with this product code already exists.");

            await _productService.CreateProduct(product);

            return NoContent();
        }


        /// <summary>
        /// Update product stock.
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <param name="newStock">How many pieces of product was stocked or remove from warehouse
        /// eg. -1 means that 1 piece was sold
        /// eg. 1 means that 1 piece was stocked
        /// </param>
        /// <response code="200">Stock was updated</response>
        /// <response code="400">If product not found</response>
        [HttpPost]
        public async Task<IActionResult> UpdateStockAsync(int productId, int newStock)
        {
            if (productId < 0)
                return BadRequest("Product id cannot be lower than 0");


            if (!await _productService.ProductExistById(productId))
                return BadRequest("Product not found");

            await _productService.UpdateStockAsync(productId, newStock);

            return Ok(null);
        }
    }
}
