using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Product.API.Examples;
using Product.API.Examples.CreateProduct;
using Product.API.Examples.GetAllProducts;
using Product.API.Examples.GetProduct;
using Product.API.Examples.UpdateStock;
using Product.Domain.Interfaces.v1;
using Product.Domain.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace Product.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    [ApiVersion(1)]
    [Obsolete("This controller is deprecated, please use API v2 instead.")]
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
        [Microsoft.AspNetCore.Mvc.HttpGet(nameof(GetAllProducts))]   

        [Produces("application/json")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetAllProductsExample1_Response))]
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
        [Microsoft.AspNetCore.Mvc.HttpGet(nameof(GetProduct))]

        [Produces("application/json")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetProductExample1_Response))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(NotFoundErrorExample))]
        public async Task<ActionResult<Product.Domain.Models.Product>> GetProduct(int id)
        {
            Product.Domain.Models.Product? product = await _productService.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }





        /// <summary>
        /// Create new product.
        /// </summary>
        /// <param name="product"></param>
        /// <response code="201">Product was created</response>
        /// <response code="400">Product was not created because of bad parameters or because the product is already exist</response>
        [HttpPut(nameof(CreateProduct))]

        [Produces("application/json")]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(CreateProductExample1_Response))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(BadRequestErrorExample))]
        [SwaggerRequestExample(typeof(CreateProduct), typeof(CreateProductExample1_Request))]

        public async Task<IActionResult> CreateProduct(CreateProduct product)
        {
            if (product == null)
                return BadRequest("Product cannot be null");


            if (!string.IsNullOrEmpty(product.ProductCode) && await _productService.ProductExistByProductCode(product.ProductCode))
                return BadRequest("Product with this product code already exists.");

            await _productService.CreateProduct(product);

            return Created();
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
        /// <response code="400">If product not found or is not in warehouse</response>
        [HttpPatch(nameof(UpdateStock))]

        [Produces("application/json")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UpdateStockExample1_Response))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(BadRequestErrorExample))]
        [SwaggerRequestExample(typeof(UpdateStock), typeof(UpdateStockExample1_Request))]
        public async Task<IActionResult> UpdateStock(UpdateStock updateStock)
        {
            if (updateStock == null)
                return BadRequest("Object cannot be null");

            if (updateStock.ProductId < 0)
                return BadRequest("Product id cannot be lower than 0");


            if (!await _productService.ProductExistById(updateStock.ProductId))
                return BadRequest("Product not found");

            int stock = await _productService.UpdateStock(updateStock);

            if (stock < 0)
                return BadRequest("It is not possible order this product, becase is not in warehouse");

            return Ok(null);
        }
    }
}
