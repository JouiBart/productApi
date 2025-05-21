using Asp.Versioning;
using Eshop.ServiceDefaults.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using Product.API.Examples;
using Product.API.Examples.CreateProduct;
using Product.API.Examples.GetAllProducts;
using Product.API.Examples.GetProduct;
using Product.API.Examples.UpdateStock;
using Product.Domain.Enums;
using Product.Domain.Interfaces.v2;
using Product.Domain.Models;
using RabbitMQ.Client;
using Swashbuckle.AspNetCore.Filters;
using System.Data.Common;
using System.Net;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Product.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    [ApiVersion(2)]
    public class ProductController_v2 : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IProductCacheService_v2 _productService;
        private readonly IConnection _connection;



        public ProductController_v2(
        ILogger<ProductController> logger, IProductCacheService_v2 productService, IConnection connection)
        {
            _logger = logger;
            _productService = productService;
            _connection = connection;
        }



        /// <summary>
        /// Get maximum of 100 products with pagination and order.
        /// </summary>
        /// <param name="currentPage">Current page of the product list</param>
        /// <param name="pageSize">How many products should be maximum send on one page (MAX 100!). Default page size is 10</param>
        /// <param name="order">Order of the products in the list.  Can be: 
        /// "prod_asc" "prod_desc" - order by product name
        /// "price_asc" "price_desc" - order by product price
        /// 
        /// NOTE: Default order is "prod_asc"
        /// </param>
        /// <response code="200">List of all products</response>
        [HttpGet(nameof(GetAllProducts))]   

        [Produces("application/json")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetAllProductsExample1_Response))]
        public async Task<ActionResult<IEnumerable<Product.Domain.Models.Product>>> GetAllProducts(int currentPage = 1, int pageSize = 10, ProductOrderEnum order = ProductOrderEnum.ProdAsc)
        {
            if (currentPage < 1)
                return BadRequest("Current page cannot be lower than 1");

            if (pageSize < 1)
                return BadRequest("Page size cannot be lower than 1");

            if (pageSize > 100)
                return BadRequest("Page size cannot be higher than 100");

            return Ok(await _productService.GetAllProducts(currentPage, pageSize, order));
        }





        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">id of product</param>
        /// <response code="200">Single product</response>
        /// <response code="404">Product not exist</response>
        [HttpGet(nameof(GetProduct))]

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


            if (await _productService.ProductExistByProductCode(product.ProductCode))
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

            var queueName = ProductQueues.UpdateStock;
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queueName, exclusive: false, durable: true);
            channel.BasicPublish(exchange: "", queueName, null, body: JsonSerializer.SerializeToUtf8Bytes(updateStock));

            return Ok(null);
        }
    }
}
